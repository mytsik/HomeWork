namespace _0302
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
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonEntry = new Button();
            SuspendLayout();
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(193, 95);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(156, 23);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(193, 146);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(156, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 77);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 2;
            label1.Text = "Введите логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(193, 128);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 3;
            label2.Text = "Введите пароль:";
            // 
            // buttonEntry
            // 
            buttonEntry.Location = new Point(235, 185);
            buttonEntry.Name = "buttonEntry";
            buttonEntry.Size = new Size(75, 23);
            buttonEntry.TabIndex = 4;
            buttonEntry.Text = "Войти";
            buttonEntry.UseVisualStyleBackColor = true;
            buttonEntry.Click += buttonEntry_Click;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(553, 287);
            Controls.Add(buttonEntry);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Name = "AuthorizationForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label label1;
        private Label label2;
        private Button buttonEntry;
    }
}
