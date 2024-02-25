namespace _2001
{
    partial class AuthorizationForm
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
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            groupBindingSource = new BindingSource(components);
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)groupBindingSource).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DataSource = groupBindingSource;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(150, 108);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 23);
            comboBox1.TabIndex = 0;
            // 
            // groupBindingSource
            // 
            groupBindingSource.DataSource = typeof(Group);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(150, 90);
            label1.Name = "label1";
            label1.Size = new Size(222, 15);
            label1.TabIndex = 1;
            label1.Text = "Выберите свою группу пользователей:";
            // 
            // button1
            // 
            button1.Location = new Point(226, 159);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 275);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "AuthorizationForm";
            Text = "AuthorizationForm";
            Load += AuthorizationForm_Load;
            ((System.ComponentModel.ISupportInitialize)groupBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private BindingSource groupBindingSource;
        private Label label1;
        private Button button1;
    }
}
