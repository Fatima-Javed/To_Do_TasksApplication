using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VP_Mids_Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Tasktitle = textBox1.Text;
            string Taskdescription = richTextBox1.Text;
            string Tasktype = "Home Task";
            if (radioButton1.Checked == true)
            {
                Tasktype = "University Task";
            }
            string Taskdeadline = dateTimePicker1.Value.ToString();
            string Tasklevel = "Important";
            if (radioButton3.Checked == true)
            {
                Tasklevel = "Normal";
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\VP Mids Lab\VP Mids Lab\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            string query = "INSERT INTO Tasks(TaskTitle,TaskDescription,TaskType,TaskDeadline,TaskLevel) VALUES('" + Tasktitle + "','" + Taskdescription + "','" + Tasktype + "','" + Taskdeadline + "','" + Tasklevel + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Data Inserted");
            }
            else if (i == 0)
            {
                MessageBox.Show("Sorry! Data not Inserted");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\VP Mids Lab\VP Mids Lab\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select  * from Tasks", con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\VP Mids Lab\VP Mids Lab\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            string deleteData = textBox2.Text;

            string query = "delete  from Tasks where  TaskID =" + deleteData;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;

            label8.Text = "Data Deleted!";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\VP Mids Lab\VP Mids Lab\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            string type = radioButton2.Text;
         
            string query = "SELECT * FROM Tasks where TaskType = 'University Task'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\VP Mids Lab\VP Mids Lab\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            string type = radioButton1.Text;


            string query = "SELECT * FROM Tasks where TaskType = 'Home Task'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\VP Mids Lab\VP Mids Lab\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Tasks where TaskLevel = 'Important'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\VP Mids Lab\VP Mids Lab\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Tasks where TaskLevel = 'Normal'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;

        }
    }
}
