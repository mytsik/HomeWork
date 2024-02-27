using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0802_2
{
    public partial class SecondForm : Form
    {
        public SecondForm(string strLogin)
        {
            InitializeComponent();
            labelLogin2.Text = strLogin;
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm fmMain = new MainForm(labelLogin2.Text);
            fmMain.ShowDialog();
        }
    }
}
