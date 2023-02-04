using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;

namespace B1FormsApp1
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
                con.Open();
            try
            {
                SqlCommand command = new SqlCommand("insert into Customer values ('" + int.Parse(textBox1.Text) + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox7.Text + "')", con);

                command.ExecuteNonQuery();
                /*
                cmd.Parameters.AddWithValue("@O_ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Product_ID", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@R_ID", int.Parse(textBox3.Text))(textBox3.Text.Trim()==string.Empty)?null :.value.int.Parse);
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBox4.Text));
               
                */
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bakeryBDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.bakeryBDataSet.Customer);

        }


        private void update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string Customer_ID = textBox1.Text;
            string First_Name = textBox3.Text;
            string Last_Name = textBox4.Text;
            string Phone = textBox6.Text;
            string Email = textBox5.Text;
            string Area = textBox2.Text;
            string City = textBox7.Text;
            //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
            string Query = "UPDATE Customer SET First_Name='" + First_Name + "' , Last_Name='" + Last_Name + "' , Phone='" + Phone + "' , Email='" + Email + "' , Area='" + Area + "' , City='" + City + "' WHERE Customer_ID='" + Customer_ID + "'";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //close
            con.Close();
            MessageBox.Show("Data has been updated");
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";

        }

        private void Show_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            
            //prepare Querey
            string Query = "Select * from Customer";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            DataTable table= new DataTable();
            table.Load(reader);
            dataGridView1.DataSource= table;

            //close
            con.Close();
            
        }
        private void dataGridView1_CellContentClick(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            //prepare Querey
            string Customer_ID = textBox1.Text;

            //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
            string Query = "DELETE FROM Customer  WHERE Customer_ID='" + Customer_ID + "'";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //close
            con.Close();
            MessageBox.Show("Data has been DELETED");
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";
        }

        
        private void Fetch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            //prepare Querey
            string Customer_ID = textBox1.Text;

            //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
            string Query = "SELECT * FROM Customer  WHERE Customer_ID= " + Customer_ID ;
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                textBox3.Text = reader["First_Name"].ToString();
                textBox4.Text = reader["Last_Name"].ToString();
                textBox5.Text = reader["Phone"].ToString();
                textBox6.Text = reader["Email"].ToString();
                textBox2.Text = reader["Area"].ToString();
                textBox7.Text = reader["City"].ToString();
            }
          
            else 

                MessageBox.Show("No record found"); 

            con.Close();
           
        }
    }
}


