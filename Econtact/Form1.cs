using Econtact.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econtact
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ContactClass c=new ContactClass();
        private void button1_Click(object sender, EventArgs e)
        {
            c.FirstName=textBox2.Text;
            c.LastName=textBox3.Text;
            c.ContactNo=textBox4.Text;
            c.Address=textBox5.Text;
            c.Gender = comboBox1.Text;
            bool success = c.Insert(c);
            if (success==true)
            {
                MessageBox.Show("Data insert successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Please inter valid data");
            }
            //Load Data into Grid View
            DataTable dt= c.Select();
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }
        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.FirstName = textBox2.Text;
            c.LastName = textBox3.Text;
            c.ContactNo = textBox4.Text;
            c.Address = textBox5.Text;
            c.Gender = comboBox1.Text;
            bool success = c.Update(c);
            if (success == true)
            {
                MessageBox.Show("Data Update successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Please inter valid data");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.ContactId = Convert.ToInt32(textBox1.Text);
            bool success = c.Delete(c);
            if (success==true)
            {
                MessageBox.Show("Delete successfully");
            }
            else
            {
                MessageBox.Show("Failed to delete");
            }
        }
    }
}
