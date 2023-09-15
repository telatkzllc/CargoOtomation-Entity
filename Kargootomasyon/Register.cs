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

namespace Kargootomasyon
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server =.;Database=Kargo;Integrated Security=true;");
        public void temizleme()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "kargoekle";
            cmd.Parameters.AddWithValue("@userrId", textBox1.Text);
            cmd.Parameters.AddWithValue("@passwordd", textBox2.Text);
            cmd.ExecuteNonQuery();
            temizleme();
            conn.Close();
            loginold go = new loginold();
            go.Show();
            this.Hide();
            }
            catch
            {
                MessageBox.Show("Düzgün Giriniz");
            }
           
        }
    }
}
