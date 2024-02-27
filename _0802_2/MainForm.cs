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
    public partial class MainForm : Form
    {
        public MainForm(string strTextBox)
        {
            InitializeComponent();
            labelLogin.Text = strTextBox;
        }

        private void buttonFirstForm_Click(object sender, EventArgs e)
        {
            Hide();
            FirstForm fmFirst = new FirstForm(labelLogin.Text);
            fmFirst.ShowDialog();
        }

        private void buttonSecondForm_Click(object sender, EventArgs e)
        {
            Hide();
            SecondForm fmSecond = new SecondForm(labelLogin.Text);
            fmSecond.ShowDialog();
        }

        private void buttonThirdForm_Click(object sender, EventArgs e)
        {
            Hide();
            ThirdForm fmThird = new ThirdForm(labelLogin.Text);
            fmThird.ShowDialog();
        }
    }
}
