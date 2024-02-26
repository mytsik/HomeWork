using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Npgsql;
using System.Drawing.Text;
using System.Collections;

namespace _0302
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        string connStr = "Server=localhost;Port=5432;Database=Practice;User Id=postgres;Password=24601;";
        int attempts = 3;

        private void buttonEntry_Click(object sender, EventArgs e)
        {           
            List<string> userList = [];

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand("SELECT login FROM public.user2 WHERE " +
                    "login='" + textBoxLogin.Text + "' AND passw='" + textBoxPassword.Text + "' ", connection);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userList.Add(reader.GetString(0));
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            if (userList.Count != 0)
            {
                Hide();
                MainForm fmMain = new MainForm();
                fmMain.ShowDialog();
            }
            else
            {
                attempts -= 1;
                MessageBox.Show($"Логин и/или пароль введены не верно! Осталось попыток: {attempts}");

                if (attempts == 0)
                {
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 20000;
                    timer.Tick += timer_Tick;
                    timer.Start();

                    textBoxLogin.Enabled = false;
                    textBoxPassword.Enabled = false;
                    buttonEntry.Enabled = false;

                    attempts = 3;
                }
            }

            textBoxLogin.Text = "";
            textBoxPassword.Text = "";

        }
        
        private async void timer_Tick(object sender, EventArgs e)
        {
            textBoxLogin.Enabled = true;
            textBoxPassword.Enabled = true;
            buttonEntry.Enabled = true;
        }
    }
}
