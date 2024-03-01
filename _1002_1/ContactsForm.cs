using Npgsql;
using System.Data;

namespace _1002_1
{
    public partial class ContactsForm : Form
    {
        public ContactsForm()
        {
            InitializeComponent();

        }

        string connStr = "Server=localhost;Port=5432;Database=HomeWork;User Id=postgres;Password=24601;";

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("Необходимо ввести данные для добавления!");
                return;
            }

            try
            {
                List<int> idList = [];

                NpgsqlConnection sqlConnection = new NpgsqlConnection(connStr);
                sqlConnection.Open();

                NpgsqlCommand command1 = new NpgsqlCommand();
                command1.Connection = sqlConnection;
                command1.CommandType = CommandType.Text;
                command1.CommandText = "SELECT id FROM public.contact";

                NpgsqlDataReader dataReader1 = command1.ExecuteReader();
                if (dataReader1.HasRows)
                {
                    while (dataReader1.Read())
                    {
                        idList.Add(dataReader1.GetInt32(0));
                    }
                }
                command1.Dispose();
                dataReader1.Close();

                int id = idList.Max() + 1;

                NpgsqlCommand command2 = new NpgsqlCommand();
                command2.Connection = sqlConnection;
                command2.CommandType = CommandType.Text;
                command2.CommandText = String.Format("INSERT INTO public.contact(id, name, number) VALUES ('{0}', '{1}', '{2}')",
                     id, textBox1.Text, textBox2.Text);

                NpgsqlDataReader dataReader2 = command2.ExecuteReader();
                if (dataReader2.HasRows)
                {
                    DataTable data = new DataTable();
                    data.Load(dataReader2);
                    dataGridView1.DataSource = data;
                }
                command2.Dispose();
                dataReader2.Close();

                sqlConnection.Close();
                SqlConnectionReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("Необходимо выбрать строку для удаления!");
                return;
            }

            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(connStr);
                sqlConnection.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = String.Format("DELETE FROM public.contact WHERE name = '{0}' AND number = '{1}'",
                    textBox1.Text, textBox2.Text);

                NpgsqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable data = new DataTable();
                    data.Load(dataReader);
                    dataGridView1.DataSource = data;
                }

                command.Dispose();
                sqlConnection.Close();
                SqlConnectionReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("Необходимо ввести данные для обновления!");
                return;
            }

            string oldName = "";
            string oldNumber = "";
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                oldName = row.Cells[0].Value.ToString();
                oldNumber = row.Cells[1].Value.ToString();
            }

            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(connStr);
                sqlConnection.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = String.Format("UPDATE public.contact SET name = '{0}', number = '{1}' WHERE name = '{2}' AND number = '{3}'",
                    textBox1.Text, textBox2.Text, oldName, oldNumber);

                NpgsqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable data = new DataTable();
                    data.Load(dataReader);
                    dataGridView1.DataSource = data;
                }

                command.Dispose();
                sqlConnection.Close();
                SqlConnectionReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
            }
        }

        private void SqlConnectionReader()
        {
            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(connStr);
                sqlConnection.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT name, number FROM public.contact ORDER BY name ASC";

                NpgsqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable data = new DataTable();
                    data.Load(dataReader);
                    dataGridView1.DataSource = data;
                }

                command.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void ContactsForm_Load(object sender, EventArgs e)
        {
            SqlConnectionReader();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Необходимо ввести имя для поиска!");
                return;
            }

            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(connStr);
                sqlConnection.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = String.Format("SELECT * FROM public.contact WHERE name = '{0}'", textBox1.Text);

                NpgsqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable data = new DataTable();
                    data.Load(dataReader);
                    dataGridView1.DataSource = data;
                }

                command.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
