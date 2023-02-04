using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B1FormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer f4= new Customer();
            f4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Employee f5= new Employee();    
            f5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order f6=new Order();
            f6.Show();  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OrderDetails f7=new OrderDetails(); 
            f7.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f8= new Form4();
            f8.Show();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReturnDetail f9=new ReturnDetail(); 
            f9.Show();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Branch f10=new Branch();    
            f10.Show(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Discount f11=new Discount();    
            f11.Show(); 
        }
    }
}
