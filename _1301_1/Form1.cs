using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1301_1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word=Microsoft.Office.Interop.Word;

namespace _1301_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        BindingList<_1301_1.One> data1 = new BindingList<_1301_1.One>();
        string conn = "Server=localhost;Port=5432;Database=HomeWork;User Id=postgres;Password=24601;";
        string path = "C:\\Users\\Yanina\\OneDrive\\Рабочий стол\\HomeWork13011.doc";

        public void DGRefresh1()
        {
            data1.Clear();
            using (_1301_1.OneContext db = new OneContext(conn))
            {
                List<One> infolist = db.one.FromSqlRaw("SELECT * FROM public.one").ToList();                
                for (int i = 0; i < infolist.Count(); i++)
                {
                    data1.Add(infolist[i]);
                    dataGridView1.DataSource = data1;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data1;
            DGRefresh1();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            var Wordapp = new Word.Application();
            Wordapp.WindowState = Word.WdWindowState.wdWindowStateNormal;
            Word.Document doc = Wordapp.Documents.Add(Visible: true);

            Word.Paragraph par1 = doc.Paragraphs.Add();            
            par1.Range.Text = "Компания ООО\r\n\"СтройМодерн\"\r\n\r\n\r\n\r\n";
            par1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

            Word.Paragraph par2 = doc.Paragraphs.Add();
            par2.Range.Text = "ЧЕК";
            par2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            object start = 33;
            object end = doc.Content.End;
            Word.Range range = doc.Range(ref start, ref end);

            try
            {
                Word.Table table = doc.Tables.Add(range, dataGridView1.RowCount, dataGridView1.ColumnCount);
                table.Borders.Enable = 1;
                table.Cell(1, 1).Range.Text = "Название товара";
                table.Cell(1, 2).Range.Text = "Кол-во";
                table.Cell(1, 3).Range.Text = "Цена";
                table.Cell(1, 4).Range.Text = "Итоговая сумма";
                table.Range.Bold = 1;
                table.Range.Font.Name = "verbana";
                table.Range.Font.Size = 10;
                table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                int k, i;
                for (k = 0, i = 2; i <= dataGridView1.RowCount; i++, k++)
                {
                    table.Cell(i, 1).Range.Text = dataGridView1.Rows[k].Cells[0].Value.ToString();
                    table.Cell(i, 2).Range.Text = dataGridView1.Rows[k].Cells[1].Value.ToString();
                    table.Cell(i, 3).Range.Text = dataGridView1.Rows[k].Cells[2].Value.ToString();
                    table.Cell(i, 4).Range.Text = dataGridView1.Rows[k].Cells[3].Value.ToString();
                }
                doc.SaveAs(path, ReadOnlyRecommended: false);
                doc.Close();
                Wordapp.Quit();
                MessageBox.Show("Файл 'HomeWork13011.doc' сохранен на Рабочий стол.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            try
            {
                var Wordapp2 = new Word.Application();
                Word.Document doc2 = Wordapp2.Documents.Open(path, ReadOnly: false);

                doc2.ExportAsFixedFormat("C:\\Users\\Yanina\\OneDrive\\Рабочий стол\\HomeWork13011PDF.pdf", WdExportFormat.wdExportFormatPDF);
                Wordapp2.Quit();

                MessageBox.Show("Печать в PDF прошла успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
