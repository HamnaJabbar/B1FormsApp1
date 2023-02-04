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

namespace B1FormsApp1
{
    public partial class ReturnDetail : Form
    {
        public ReturnDetail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand("insert into Return_Detail values ('" + int.Parse(textBox1.Text) + "','" + int.Parse(textBox2.Text) + "','" + int.Parse(textBox3.Text) + "','" + (textBox4.Text) + "')", con);

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
            string R_ID = textBox1.Text;



            string Query = "DELETE FROM Return_Detail WHERE R_ID='" + R_ID + "'";
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string R_ID = textBox1.Text;
            string P_ID = textBox2.Text;
            string O_ID = textBox3.Text;
            string R_Date = textBox4.Text;
            //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
            string Query = "UPDATE Return_Detail SET R_ID='" + R_ID + "' , P_ID='" + P_ID + "',O_ID='" + O_ID + "',R_Date='" + R_Date + "' WHERE R_ID='" + R_ID + "' ";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //close
            con.Close();
            MessageBox.Show("Data has been updated");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string Query = "Select * from Return_Detail";
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
