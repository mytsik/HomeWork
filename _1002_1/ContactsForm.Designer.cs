namespace _1002_1
{
    partial class ContactsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonAdd = new Button();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(63, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(344, 232);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(432, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(432, 106);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(155, 23);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(432, 37);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 3;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(432, 88);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 4;
            label2.Text = "Номер";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(476, 191);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(476, 220);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(476, 249);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 7;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(603, 55);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 8;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // ContactsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 320);
            Controls.Add(buttonSearch);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "ContactsForm";
            Text = "Form1";
            Load += ContactsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button buttonAdd;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonSearch;
    }
}
