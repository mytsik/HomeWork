namespace _0802_2
{
    partial class SecondForm
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
            labelLogin2 = new Label();
            buttonGoBack = new Button();
            SuspendLayout();
            // 
            // labelLogin2
            // 
            labelLogin2.AutoSize = true;
            labelLogin2.Location = new Point(418, 9);
            labelLogin2.Name = "labelLogin2";
            labelLogin2.Size = new Size(68, 15);
            labelLogin2.TabIndex = 0;
            labelLogin2.Text = "labelLogin2";
            // 
            // buttonGoBack
            // 
            buttonGoBack.Location = new Point(12, 9);
            buttonGoBack.Name = "buttonGoBack";
            buttonGoBack.Size = new Size(75, 23);
            buttonGoBack.TabIndex = 2;
            buttonGoBack.Text = "Назад";
            buttonGoBack.UseVisualStyleBackColor = true;
            buttonGoBack.Click += buttonGoBack_Click;
            // 
            // SecondForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 288);
            Controls.Add(buttonGoBack);
            Controls.Add(labelLogin2);
            Name = "SecondForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SecondForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin2;
        private Button buttonGoBack;
    }
}