namespace _2001
{
    partial class AdminForm
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
            GoBackButton = new Button();
            SuspendLayout();
            // 
            // GoBackButton
            // 
            GoBackButton.Location = new Point(12, 12);
            GoBackButton.Name = "GoBackButton";
            GoBackButton.Size = new Size(75, 23);
            GoBackButton.TabIndex = 0;
            GoBackButton.Text = "Назад";
            GoBackButton.UseVisualStyleBackColor = true;
            GoBackButton.Click += GoBackButton_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(GoBackButton);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button GoBackButton;
    }
}