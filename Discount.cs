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
    public partial class Discount : Form
    {
        public Discount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand("insert into discounts values ('" +int.Parse(textBox1.Text) + "','" + (textBox2.Text) + "','" + int.Parse(textBox3.Text) + "','" + int.Parse(textBox4.Text) + "','" + decimal.Parse(textBox5.Text)  +  "')", con);

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
            try
            {
                //prepare Querey
                string discount_ID = textBox1.Text;
                

                string Query = "DELETE FROM discounts WHERE discount_ID='" + discount_ID + "'";
                //execute query
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //close
            finally
            {
                con.Close();
                MessageBox.Show("Data has been DELETED");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
               
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();
            try
            {
                //prepare Querey

                string discount_ID = textBox1.Text;
                string discounttype = textBox2.Text;
                string Branch_id = textBox3.Text;
                string Product_ID = textBox4.Text;
                string discount = textBox5.Text;

                //string Query = "INSERT INTO Customer(FirstName, SecondName, Phone,Email,Area,City) Values ('" + FirstName + "','" + SecondName + "', '" + Phone + "','" + Email + "','" + Area + "','" + City + "')";
                string Query = "UPDATE discounts SET discount_ID='" + discount_ID + "' , discounttype='" + discounttype + "',Branch_iD='" + Branch_id + "',Branch_iD='" + Branch_id + "',discount= '" + discount + "' WHERE discount_ID='" + discount_ID + "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                //close
                con.Close();
                MessageBox.Show("Data has been updated");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }

        }
        

private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-81COF93;Initial Catalog=BakeryB;Integrated Security=True");
            con.Open();

            //prepare Querey
            string Query = "Select * from discounts";
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
