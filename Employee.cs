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

namespace B1FormsApp1
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand("insert into Employee values ('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                MessageBox.Show("Successfully inserted");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            //prepare Querey
            string Employee_ID = textBox1.Text;

            //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
            string Query = "DELETE FROM Employee  WHERE Employee_ID='" + Employee_ID + "'";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //close
            con.Close();
            MessageBox.Show("Data has been DELETED");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string Employee_ID = textBox1.Text;
            string First_Name = textBox2.Text;
            string Last_Name = textBox3.Text;
            string City = textBox4.Text;
            string Salary = textBox5.Text;

            string Query = "UPDATE Employee SET First_Name='" + First_Name + "' , Last_Name='" + Last_Name + "' , City='" + City + "' , Salary='" + Salary + "' WHERE Employee_ID='" + Employee_ID + "'";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //close
            con.Close();
            MessageBox.Show("Data has been updated");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string Query = "select * from view_for_Admin";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;

            //close
            con.Close();
            */
            string connectionString = "Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string Query = "select * from view_for_Admin";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, connection);
            var reader = cmd.ExecuteReader();
            //       while (reader.Read())
            //      {
            //         dataGridView1.Rows.Add(reader["Employee_ID"], reader["First_Name"], reader["Last_Name"], reader["City"]);

            //            }
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;


            connection.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
    

