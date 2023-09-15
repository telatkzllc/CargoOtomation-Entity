using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Kargootomasyon
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GCRUD.cListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer cst = new customer();
            cst.CustomerId =int.Parse(textBox1.Text);
            cst.CustomerNameSurname = textBox2.Text;
            cst.CustomerAdress =(textBox3.Text);
            cst.CustomerPayment = textBox4.Text;
            cst.EmployeeId = Convert.ToInt32(textBox5.Text);
            GCRUD.cAdd(cst);
            dataGridView1.DataSource = GCRUD.cListele();
        }

        private void button3_Click(object sender, EventArgs e) //Olmadı. İKİ KOLON AYNI OLUYOR.
        {
            customer cst = new customer();
            cst.CustomerId = Convert.ToInt32(textBox1.Text);
            cst.CustomerNameSurname= textBox2.Text;
            cst.CustomerAdress = textBox3.Text;
            cst.CustomerPayment= textBox4.Text;
            cst.EmployeeId = Convert.ToInt32(textBox5.Text);


            if(!GCRUD.cUpdate(cst))
            MessageBox.Show("Update BAŞARISIZ");
            dataGridView1.DataSource=GCRUD.cListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer cst = new customer();
            cst.CustomerId = Convert.ToInt32(textBox1.Text);
            if (!GCRUD.cDelete(cst))
                MessageBox.Show("SİLME BAŞARISIZ");
            dataGridView1.DataSource = GCRUD.cListele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu go = new MainMenu();
            go.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e) //bunu orhuna sor.
        {
            customer cmd= new customer();
            cmd.CustomerNameSurname =textBox6.Text;
            dataGridView1.DataSource = GCRUD.CustomerSearch(cmd);
        }
    }
}
