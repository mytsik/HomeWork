using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.Diagnostics;
using System.IO;

namespace TextEditor
{
	public partial class FindAndReplaceForm : Form
	{
		public FindAndReplaceForm()
		{
			InitializeComponent();
			_search = new TextEditorSearcher();
		}

		TextEditorSearcher _search;
		TextEditorControl _editor;
		TextEditorControl Editor { 
			get { return _editor; } 
			set { 
				_editor = value;
				_search.Document = _editor.Document;
				UpdateTitleBar();
			}
		}

		private void UpdateTitleBar()
		{
			string text = ReplaceMode ? "Find & replace" : "Find";
			if (_editor != null && _editor.FileName != null)
				text += " - " + Path.GetFileName(_editor.FileName);
			if (_search.HasScanRegion)
				text += " (selection only)";
			this.Text = text;
		}

		public void ShowFor(TextEditorControl editor, bool replaceMode)
		{
			Editor = editor;

			_search.ClearScanRegion();
			var sm = editor.ActiveTextAreaControl.SelectionManager;
			if (sm.HasSomethingSelected && sm.SelectionCollection.Count == 1) {
				var sel = sm.SelectionCollection[0];
				if (sel.StartPosition.Line == sel.EndPosition.Line)
					txtLookFor.Text = sm.SelectedText;
				else
					_search.SetScanRegion(sel);
			} else {
				Caret caret = editor.ActiveTextAreaControl.Caret;
				int start = TextUtilities.FindWordStart(editor.Document, caret.Offset);
				int endAt = TextUtilities.FindWordEnd(editor.Document, caret.Offset);
				txtLookFor.Text = editor.Document.GetText(start, endAt - start);
			}
			
			ReplaceMode = replaceMode;

			this.Owner = (Form)editor.TopLevelControl;
			this.Show();
			
			txtLookFor.SelectAll();
			txtLookFor.Focus();
		}

		public bool ReplaceMode
		{
			get { return txtReplaceWith.Visible; }
			set {
				btnReplace.Visible = btnReplaceAll.Visible = value;
				lblReplaceWith.Visible = txtReplaceWith.Visible = value;
				btnHighlightAll.Visible = !value;
				this.AcceptButton = value ? btnReplace : btnFindNext;
				UpdateTitleBar();
			}
		}

		private void btnFindPrevious_Click(object sender, EventArgs e)
		{
			FindNext(false, true, "Text not found");
		}
		private void btnFindNext_Click(object sender, EventArgs e)
		{
			FindNext(false, false, "Text not found");
		}

		public bool _lastSearchWasBackward = false;
		public bool _lastSearchLoopedAround;

		public TextRange FindNext(bool viaF3, bool searchBackward, string messageIfNotFound)
		{
			if (string.IsNullOrEmpty(txtLookFor.Text))
			{
				MessageBox.Show("No string specified to look for!");
				return null;
			}
			_lastSearchWasBackward = searchBackward;
			_search.LookFor = txtLookFor.Text;
			_search.MatchCase = chkMatchCase.Checked;
			_search.MatchWholeWordOnly = chkMatchWholeWord.Checked;

			var caret = _editor.ActiveTextAreaControl.Caret;
			if (viaF3 && _search.HasScanRegion && !caret.Offset.
				IsInRange(_search.BeginOffset, _search.EndOffset)) {
				_search.ClearScanRegion();
				UpdateTitleBar();
			}

			int startFrom = caret.Offset - (searchBackward ? 1 : 0);
			TextRange range = _search.FindNext(startFrom, searchBackward, out _lastSearchLoopedAround);
			if (range != null)
				SelectResult(range);
			else if (messageIfNotFound != null)
				MessageBox.Show(messageIfNotFound);
			return range;
		}

		private void SelectResult(TextRange range)
		{
			TextLocation p1 = _editor.Document.OffsetToPosition(range.Offset);
			TextLocation p2 = _editor.Document.OffsetToPosition(range.Offset + range.Length);
			_editor.ActiveTextAreaControl.SelectionManager.SetSelection(p1, p2);
			_editor.ActiveTextAreaControl.ScrollTo(p1.Line, p1.Column);
			_editor.ActiveTextAreaControl.Caret.Position = 
				_editor.Document.OffsetToPosition(range.Offset + range.Length);
		}

		Dictionary<TextEditorControl, HighlightGroup> _highlightGroups = new Dictionary<TextEditorControl, HighlightGroup>();

		private void btnHighlightAll_Click(object sender, EventArgs e)
		{
			if (!_highlightGroups.ContainsKey(_editor))
				_highlightGroups[_editor] = new HighlightGroup(_editor);
			HighlightGroup group = _highlightGroups[_editor];

			if (string.IsNullOrEmpty(LookFor))
				group.ClearMarkers();
			else {
				_search.LookFor = txtLookFor.Text;
				_search.MatchCase = chkMatchCase.Checked;
				_search.MatchWholeWordOnly = chkMatchWholeWord.Checked;

				bool looped = false;
				int offset = 0, count = 0;
				for(;;) {
					TextRange range = _search.FindNext(offset, false, out looped);
					if (range == null || looped)
						break;
					offset = range.Offset + range.Length;
					count++;

					var m = new TextMarker(range.Offset, range.Length, 
							TextMarkerType.SolidBlock, Color.Yellow, Color.Black);
					group.AddMarker(m);
				}
				if (count == 0)
					MessageBox.Show("Search text not found.");
				else
					Close();
			}
		}
		
		private void FindAndReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				if (this.Owner != null)
					this.Owner.Select();
				
				e.Cancel = true;
				Hide();
				_search.ClearScanRegion();
				_editor.Refresh();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnReplace_Click(object sender, EventArgs e)
		{
			var sm = _editor.ActiveTextAreaControl.SelectionManager;
			if (string.Equals(sm.SelectedText, txtLookFor.Text, StringComparison.OrdinalIgnoreCase))
				InsertText(txtReplaceWith.Text);
			FindNext(false, _lastSearchWasBackward, "Text not found.");
		}

		private void btnReplaceAll_Click(object sender, EventArgs e)
		{
			int count = 0;
			_editor.ActiveTextAreaControl.Caret.Position = 
				_editor.Document.OffsetToPosition(_search.BeginOffset);

			_editor.Document.UndoStack.StartUndoGroup();
			try {
				while (FindNext(false, false, null) != null)
				{
					if (_lastSearchLoopedAround)
						break;
					count++;
					InsertText(txtReplaceWith.Text);
				}
			} finally {
				_editor.Document.UndoStack.EndUndoGroup();
			}
			if (count == 0)
				MessageBox.Show("No occurrances found.");
			else {
				MessageBox.Show(string.Format("Replaced {0} occurrances.", count));
				Close();
			}
		}

		private void InsertText(string text)
		{
			var textArea = _editor.ActiveTextAreaControl.TextArea;
			textArea.Document.UndoStack.StartUndoGroup();
			try {
				if (textArea.SelectionManager.HasSomethingSelected) {
					textArea.Caret.Position = textArea.SelectionManager.SelectionCollection[0].StartPosition;
					textArea.SelectionManager.RemoveSelectedText();
				}
				textArea.InsertString(text);
			} finally {
				textArea.Document.UndoStack.EndUndoGroup();
			}
		}

		public string LookFor { get { return txtLookFor.Text; } }
	}

	public class TextRange : AbstractSegment
	{
		IDocument _document;
		public TextRange(IDocument document, int offset, int length)
		{
			_document = document;
			this.offset = offset;
			this.length = length;
		}
	}
	public class TextEditorSearcher : IDisposable
	{
		IDocument _document;
		public IDocument Document
		{
			get { return _document; } 
			set { 
				if (_document != value) {
					ClearScanRegion();
					_document = value;
				}
			}
		}
		TextMarker _region = null;
		public void SetScanRegion(ISelection sel)
		{
			SetScanRegion(sel.Offset, sel.Length);
		}
		public void SetScanRegion(int offset, int length)
		{
			var bkgColor = _document.HighlightingStrategy.GetColorFor("Default").BackgroundColor;
			_region = new TextMarker(offset, length, TextMarkerType.SolidBlock, 
				bkgColor.HalfMix(Color.FromArgb(160,160,160)));
			_document.MarkerStrategy.AddMarker(_region);
		}
		public bool HasScanRegion
		{
			get { return _region != null; }
		}
		public void ClearScanRegion()
		{
			if (_region != null)
			{
				_document.MarkerStrategy.RemoveMarker(_region);
				_region = null;
			}
		}
		public void Dispose() { ClearScanRegion(); GC.SuppressFinalize(this); }
		~TextEditorSearcher() { Dispose(); }
		public int BeginOffset
		{
			get {
				if (_region != null)
					return _region.Offset;
				else
					return 0;
			}
		}
		public int EndOffset
		{
			get {
				if (_region != null)
					return _region.EndOffset;
				else
					return _document.TextLength;
			}
		}

		public bool MatchCase;

		public bool MatchWholeWordOnly;

		string _lookFor;
		string _lookFor2;
		public string LookFor
		{
			get { return _lookFor; }
			set { _lookFor = value; }
		}
		public TextRange FindNext(int beginAtOffset, bool searchBackward, out bool loopedAround)
		{
			Debug.Assert(!string.IsNullOrEmpty(_lookFor));
			loopedAround = false;

			int startAt = BeginOffset, endAt = EndOffset;
			int curOffs = beginAtOffset.InRange(startAt, endAt);

			_lookFor2 = MatchCase ? _lookFor : _lookFor.ToUpperInvariant();
			
			TextRange result;
			if (searchBackward) {
				result = FindNextIn(startAt, curOffs, true);
				if (result == null) {
					loopedAround = true;
					result = FindNextIn(curOffs, endAt, true);
				}
			} else {
				result = FindNextIn(curOffs, endAt, false);
				if (result == null) {
					loopedAround = true;
					result = FindNextIn(startAt, curOffs, false);
				}
			}
			return result;
		}

		private TextRange FindNextIn(int offset1, int offset2, bool searchBackward)
		{
			Debug.Assert(offset2 >= offset1);
			offset2 -= _lookFor.Length;
			Func<char, char, bool> matchFirstCh;
			Func<int, bool> matchWord;
			if (MatchCase)
				matchFirstCh = (lookFor, c) => (lookFor == c);
			else
				matchFirstCh = (lookFor, c) => (lookFor == Char.ToUpperInvariant(c));
			if (MatchWholeWordOnly)
				matchWord = IsWholeWordMatch;
			else
				matchWord = IsPartWordMatch;
			char lookForCh = _lookFor2[0];
			if (searchBackward)
			{
				for (int offset = offset2; offset >= offset1; offset--) {
					if (matchFirstCh(lookForCh, _document.GetCharAt(offset))
						&& matchWord(offset))
						return new TextRange(_document, offset, _lookFor.Length);
				}
			} else {
				for (int offset = offset1; offset <= offset2; offset++) {
					if (matchFirstCh(lookForCh, _document.GetCharAt(offset))
						&& matchWord(offset))
						return new TextRange(_document, offset, _lookFor.Length);
				}
			}
			return null;
		}
		private bool IsWholeWordMatch(int offset)
		{
			if (IsWordBoundary(offset) && IsWordBoundary(offset + _lookFor.Length))
				return IsPartWordMatch(offset);
			else
				return false;
		}
		private bool IsWordBoundary(int offset)
		{
			return offset <= 0 || offset >= _document.TextLength ||
				!IsAlphaNumeric(offset - 1) || !IsAlphaNumeric(offset);
		}
		private bool IsAlphaNumeric(int offset)
		{
			char c = _document.GetCharAt(offset);
			return Char.IsLetterOrDigit(c) || c == '_';
		}
		private bool IsPartWordMatch(int offset)
		{
			string substr = _document.GetText(offset, _lookFor.Length);
			if (!MatchCase)
				substr = substr.ToUpperInvariant();
			return substr == _lookFor2;
		}
	}
	public class HighlightGroup : IDisposable
	{
		List<TextMarker> _markers = new List<TextMarker>();
		TextEditorControl _editor;
		IDocument _document;
		public HighlightGroup(TextEditorControl editor)
		{
			_editor = editor;
			_document = editor.Document;
		}
		public void AddMarker(TextMarker marker)
		{
			_markers.Add(marker);
			_document.MarkerStrategy.AddMarker(marker);
		}
		public void ClearMarkers()
		{
			foreach (TextMarker m in _markers)
				_document.MarkerStrategy.RemoveMarker(m);
			_markers.Clear();
			_editor.Refresh();
		}
		public void Dispose() { ClearMarkers(); GC.SuppressFinalize(this); }
		~HighlightGroup() { Dispose(); }

		public IList<TextMarker> Markers { get { return _markers.AsReadOnly(); } }
	}
}
