using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1301_2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word = Microsoft.Office.Interop.Word;


namespace _1301_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        BindingList<_1301_2.Task> data1 = new BindingList<_1301_2.Task>();
        string conn = "Server=localhost;Port=5432;Database=HomeWork;User Id=postgres;Password=24601;";


        public void DGRefresh1()
        {
            data1.Clear();
            using (_1301_2.TaskContext db = new TaskContext(conn))
            {
                var infolist = db.task.FromSqlRaw("SELECT * FROM public.task").ToList();
                
                for (int i = 0; i < infolist.Count(); i++)
                {
                    data1.Add(infolist[i]);
                    dataGridView1.DataSource = data1;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data1;
            DGRefresh1();
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (TaskContext db = new TaskContext(conn))
                {

                    db.task.Add(new Task { TaskName = textBox1.Text, Deadline = textBox2.Text, Status = textBox3.Text });
                    db.SaveChanges();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    DGRefresh1();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (TaskContext db = new TaskContext(conn))
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        db.task.Remove(new Task { TaskName = dataGridView1.CurrentRow.Cells[0].Value.ToString(), Deadline = dataGridView1.CurrentRow.Cells[1].Value.ToString(), Status = dataGridView1.CurrentRow.Cells[2].Value.ToString() });
                        db.SaveChanges();
                        DGRefresh1();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (TaskContext db = new TaskContext(conn))
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        db.task.Update(new Task
                        {
                            TaskName = dataGridView1.CurrentRow.Cells[0].Value.ToString(),
                            Deadline = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                            Status = dataGridView1.CurrentRow.Cells[2].Value.ToString()
                        });
                        db.SaveChanges();
                        DGRefresh1();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
