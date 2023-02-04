using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B1FormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand("insert into Product values ('" + (textBox1.Text) + "','" + (textBox2.Text) + "','" + (textBox3.Text) + "','" + int.Parse(textBox4.Text) + "','" + (textBox5.Text) + "')", con);

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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            //prepare Querey
            string P_ID = textBox1.Text;

            //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
            string Query = "DELETE FROM Product WHERE P_ID='" + P_ID + "'";
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
            string P_ID = textBox1.Text;
            string P_Flavour = textBox2.Text;
            string P_Name = textBox3.Text;
            string P_Quantity = textBox4.Text;
            string P_Unit_Price = textBox5.Text;
            
            string Query = "UPDATE Product SET P_ID='" + P_ID + "' , P_Flavour='" + P_Flavour + "',P_Name='" + P_Name + "',P_Quantity='"+P_Quantity+"',P_Unit_Price = '" + P_Unit_Price + "' WHERE P_ID='" + P_ID + "' ";
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
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string Query = "Select * from Product";
            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;

            //close
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
