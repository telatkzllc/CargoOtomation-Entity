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
using System.Data.SqlClient;

namespace Kargootomasyon
{
    public partial class Shipment : Form
    {
        public Shipment()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server =.;Database=Kargo;Integrated Security=true;");
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GCRUD.sListele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            shipment shp = new shipment();
            shp.ShipmentId = Convert.ToInt32(textBox7.Text);
            if (!GCRUD.sDelete(shp))
                MessageBox.Show("Silme Başarısız");
            dataGridView1.DataSource = GCRUD.sListele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            shipment shp = new shipment();
            shp.ShipmentStart =(textBox1.Text);
            shp.ShipmentEnd= textBox2.Text;
            shp.ShipmentKm = Convert.ToInt32(textBox3.Text);
            shp.ShipmentCost = Convert.ToDecimal(textBox4.Text);
            shp.VehicleId =Convert.ToInt32(textBox5.Text);
            shp.CustomerId =Convert.ToInt32(textBox6.Text);
            GCRUD.sAdd(shp);
            dataGridView1.DataSource = GCRUD.sListele();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox7.Text = column.Cells["ShipmentId"].Value.ToString();
            textBox1.Text = column.Cells["ShipmentStart"].Value.ToString();
            textBox2.Text = column.Cells["ShipmentEnd"].Value.ToString();
            textBox3.Text = column.Cells["ShipmentKm"].Value.ToString();
            textBox4.Text = column.Cells["ShipmentCost"].Value.ToString();
            textBox5.Text = column.Cells["VehicleId"].Value.ToString();
            textBox6.Text = column.Cells["CustomerId"].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            shipment cst = new shipment();
            cst.ShipmentId = Convert.ToInt32(textBox7.Text);
            cst.ShipmentStart = textBox1.Text;
            cst.ShipmentEnd = textBox2.Text;
            cst.ShipmentKm = Convert.ToInt32(textBox3.Text);
            cst.ShipmentCost =Convert.ToDecimal(textBox4.Text);
            cst.VehicleId =Convert.ToInt32(textBox5.Text);
            cst.CustomerId = Convert.ToInt32(textBox6.Text);

            if (!GCRUD.sUpdate(cst))
                MessageBox.Show("Update BAŞARISIZ");
            dataGridView1.DataSource = GCRUD.sListele();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu go = new MainMenu();
            go.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "shipcost";
            command.Parameters.AddWithValue("@mini", textBox8.Text);
            command.Parameters.AddWithValue("@max", textBox9.Text);
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;

            conn.Close();
        }
    }
}
