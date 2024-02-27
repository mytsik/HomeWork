namespace _0802_2
{
    partial class ThirdForm
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
            labelLogin3 = new Label();
            buttonGoBack = new Button();
            SuspendLayout();
            // 
            // labelLogin3
            // 
            labelLogin3.AutoSize = true;
            labelLogin3.Location = new Point(415, 9);
            labelLogin3.Name = "labelLogin3";
            labelLogin3.Size = new Size(68, 15);
            labelLogin3.TabIndex = 0;
            labelLogin3.Text = "labelLogin3";
            // 
            // buttonGoBack
            // 
            buttonGoBack.Location = new Point(12, 9);
            buttonGoBack.Name = "buttonGoBack";
            buttonGoBack.Size = new Size(75, 23);
            buttonGoBack.TabIndex = 3;
            buttonGoBack.Text = "Назад";
            buttonGoBack.UseVisualStyleBackColor = true;
            buttonGoBack.Click += buttonGoBack_Click;
            // 
            // ThirdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 288);
            Controls.Add(buttonGoBack);
            Controls.Add(labelLogin3);
            Name = "ThirdForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ThirdForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin3;
        private Button buttonGoBack;
    }
}