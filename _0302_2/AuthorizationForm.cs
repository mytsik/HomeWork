using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2001
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        BindingList<Group> data1 = new BindingList<Group>();
        string conn = "Server=localhost;Port=5432;Database=Practice;User Id=postgres;Password=24601;";

        public void DGRefresh1()
        {
            data1.Clear();
            using (GroupContext db = new GroupContext(conn))
            {
                var infolist = db.group.FromSqlRaw("SELECT * FROM public.group").ToList();
                for (int i = 0; i < infolist.Count(); i++)
                {
                    data1.Add(infolist[i]);
                    comboBox1.DisplayMember = "GroupName";
                    comboBox1.ValueMember = "GroupName";
                    comboBox1.DataSource = data1;
                }
            }
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = data1;
            DGRefresh1();
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Администратор")
            {
                Hide();
                AdminForm fmAdmin = new AdminForm();
                fmAdmin.ShowDialog();                
            }
            else if (comboBox1.Text == "Менеджер")
            {
                Hide();
                ManagerForm fmManager = new ManagerForm();
                fmManager.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Необходимо выбрать группу!");
            }
        }
    }
}
