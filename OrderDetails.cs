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
    public partial class OrderDetails : Form
    {
        public OrderDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand("insert into Order_Detail values ('" + int.Parse(textBox1.Text) + "','" + int.Parse(textBox2.Text) + "','" + int.Parse(textBox3.Text) + "')", con);

                
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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            
            string O_ID = textBox1.Text;
            string Product_ID = textBox2.Text;
            string Quantity = textBox3.Text;
            
            //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
            string Query = "UPDATE Order_Detail SET O_ID='" + O_ID + "' , Product_ID='" + Product_ID + "',Quantity='" + Quantity + "' WHERE  O_ID='" + O_ID + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //close
            con.Close();
            MessageBox.Show("Data has been updated");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            try
            {
                //prepare Querey
                string O_ID = textBox1.Text;
                string Product_ID = textBox2.Text;

                string Query = "DELETE FROM Order_Detail WHERE O_ID='" + O_ID +  "'";
                //execute query
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //close
            finally {
                con.Close();
                MessageBox.Show("Data has been DELETED");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                
            }
        }
       
private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string Query = "Select * from Order_Detail";
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
