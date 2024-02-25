using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2001
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            AuthorizationForm fmAuthor = new AuthorizationForm();
            fmAuthor.ShowDialog();            
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
