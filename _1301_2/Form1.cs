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
using Npgsql;
using System.Drawing.Text;
using System.Collections;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                var infolist = db.task.FromSqlRaw("SELECT * FROM public.task2").ToList();
                
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

            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 60000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            //что должно происходить каждые 60 секунд
            await using var dataSource = NpgsqlDataSource.Create(conn);
            
            List<DateTime> dbDateTime = [];
            string notDone = "Не выполнено";

            try
            {
                
                await using (var cmdDateTime = dataSource.CreateCommand("SELECT deadline FROM public.task2 WHERE status='" + notDone + "' AND deadline > '" + DateTime.Now + "' "))
                await using (var reader = await cmdDateTime.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync()) //получаем все строки из поля с датами
                    {
                        dbDateTime.Add(reader.GetDateTime(0));
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DateTime dateTimeNow = DateTime.Now;
            DateTime nearestDate = dbDateTime.Min();
            TimeSpan diff = nearestDate - dateTimeNow;
            
            try
            {
                if ((diff.Days == 0) && (diff.Hours == 0) && (diff.Minutes <= 1))
                {
                    await using (var cmdTaskName = dataSource.CreateCommand("SELECT task_name FROM public.task2 WHERE deadline = '" + nearestDate + "' "))
                    await using (var reader2 = await cmdTaskName.ExecuteReaderAsync())
                    {
                        while (await reader2.ReadAsync()) //получаем строку с названием задания
                        {
                            MessageBox.Show("Срок выполнения задачи: \"" + reader2.GetString(0) + "\" скоро истечет!");
                           
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }                        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (TaskContext db = new TaskContext(conn))
                {

                    db.task.Add(new Task { TaskName = textBox1.Text, Deadline = DateTime.ParseExact(textBox2.Text, "yyyy-MM-dd HH:mm", null).ToUniversalTime(), Status = textBox3.Text });
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
                        db.task.Remove(new Task { TaskName = dataGridView1.CurrentRow.Cells[0].Value.ToString(), Deadline = DateTime.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()), Status = dataGridView1.CurrentRow.Cells[2].Value.ToString() });
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();

                DateTime dgDateTime = DateTime.Parse(row.Cells[1].Value.ToString());
                string year = dgDateTime.Year.ToString();                
                string month = AddNull(dgDateTime.Month.ToString());
                string day = AddNull(dgDateTime.Day.ToString());
                string hour = AddNull(dgDateTime.Hour.ToString());
                string minute = AddNull(dgDateTime.Minute.ToString());                
                string tbDateTime = $"{year}-{month}-{day} {hour}:{minute}";
                textBox2.Text = tbDateTime;

                textBox3.Text = row.Cells[2].Value.ToString();
            }

            string AddNull(string str)
            {
                if (str.Length < 2)
                {
                    return string.Concat("0", str);
                }
                else
                {
                    return str;
                }
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
                            TaskName = textBox1.Text,
                            Deadline = DateTime.ParseExact(textBox2.Text, "yyyy-MM-dd HH:mm", null).ToUniversalTime(),
                            Status = textBox3.Text
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
    }
}
