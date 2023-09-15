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
    public partial class loginold : Form
    {
        public loginold()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server =.;Database=Kargo;Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "kargogiris";
            cmd.Parameters.AddWithValue("@userrId", textBox1.Text);
            cmd.Parameters.AddWithValue("@passwordd", textBox2.Text);
            conn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Yapılıyor Lütfen Bekleyiniz");
                MainMenu go = new MainMenu();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız Tekrar Deneyiniz");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Register go = new Register();
            go.Show();
            this.Hide();
        }
    }
}
