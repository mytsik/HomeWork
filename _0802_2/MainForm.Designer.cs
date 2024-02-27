namespace _0802_2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonFirstForm = new Button();
            buttonSecondForm = new Button();
            buttonThirdForm = new Button();
            labelLogin = new Label();
            SuspendLayout();
            // 
            // buttonFirstForm
            // 
            buttonFirstForm.Location = new Point(148, 75);
            buttonFirstForm.Name = "buttonFirstForm";
            buttonFirstForm.Size = new Size(178, 23);
            buttonFirstForm.TabIndex = 0;
            buttonFirstForm.Text = "Перейти на первую форму";
            buttonFirstForm.UseVisualStyleBackColor = true;
            buttonFirstForm.Click += buttonFirstForm_Click;
            // 
            // buttonSecondForm
            // 
            buttonSecondForm.Location = new Point(148, 133);
            buttonSecondForm.Name = "buttonSecondForm";
            buttonSecondForm.Size = new Size(178, 23);
            buttonSecondForm.TabIndex = 1;
            buttonSecondForm.Text = "Перейти на вторую форму";
            buttonSecondForm.UseVisualStyleBackColor = true;
            buttonSecondForm.Click += buttonSecondForm_Click;
            // 
            // buttonThirdForm
            // 
            buttonThirdForm.Location = new Point(148, 191);
            buttonThirdForm.Name = "buttonThirdForm";
            buttonThirdForm.Size = new Size(178, 23);
            buttonThirdForm.TabIndex = 2;
            buttonThirdForm.Text = "Перейти на третью форму";
            buttonThirdForm.UseVisualStyleBackColor = true;
            buttonThirdForm.Click += buttonThirdForm_Click;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(405, 9);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(62, 15);
            labelLogin.TabIndex = 3;
            labelLogin.Text = "labelLogin";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 295);
            Controls.Add(labelLogin);
            Controls.Add(buttonThirdForm);
            Controls.Add(buttonSecondForm);
            Controls.Add(buttonFirstForm);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonFirstForm;
        private Button buttonSecondForm;
        private Button buttonThirdForm;
        private Label labelLogin;
    }
}