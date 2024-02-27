namespace _0802_2
{
    partial class FirstForm
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
            labelLogin1 = new Label();
            buttonGoBack = new Button();
            SuspendLayout();
            // 
            // labelLogin1
            // 
            labelLogin1.AutoSize = true;
            labelLogin1.Location = new Point(417, 9);
            labelLogin1.Name = "labelLogin1";
            labelLogin1.Size = new Size(68, 15);
            labelLogin1.TabIndex = 0;
            labelLogin1.Text = "labelLogin1";
            // 
            // buttonGoBack
            // 
            buttonGoBack.Location = new Point(12, 9);
            buttonGoBack.Name = "buttonGoBack";
            buttonGoBack.Size = new Size(75, 23);
            buttonGoBack.TabIndex = 1;
            buttonGoBack.Text = "Назад";
            buttonGoBack.UseVisualStyleBackColor = true;
            buttonGoBack.Click += buttonGoBack_Click;
            // 
            // FirstForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 287);
            Controls.Add(buttonGoBack);
            Controls.Add(labelLogin1);
            Name = "FirstForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FirstForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin1;
        private Button buttonGoBack;
    }
}