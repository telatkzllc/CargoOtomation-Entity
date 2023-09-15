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
using System.Xml;  //iki satırı biz ekledik aşağıdaki dahil.
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kargootomasyon
{
    public partial class Vehicle : Form
    {
        public Vehicle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vehicle vehicle = new vehicle();
            vehicle.VehicleId = Convert.ToInt32(textBox1.Text);
            vehicle.VehicleDriver= textBox2.Text;
            vehicle.VehicleType = (textBox3.Text);
            vehicle.VehicleCost =Convert.ToDecimal(textBox4.Text);
            GCRUD.vAdd(vehicle);
            dataGridView1.DataSource = GCRUD.vListele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GCRUD.vListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vehicle vehicle = new vehicle();
            vehicle.VehicleId = Convert.ToInt32(textBox1.Text);
            if (!GCRUD.vDelete(vehicle))
                MessageBox.Show("Silme Başarısız");
            dataGridView1.DataSource = GCRUD.vListele();
        }

        private void button3_Click(object sender, EventArgs e) //Çalışmıyor.
        {
            vehicle cst = new vehicle();
            cst.VehicleId = Convert.ToInt32(textBox1.Text);
            cst.VehicleDriver = textBox2.Text;
            cst.VehicleType = textBox3.Text;
            cst.VehicleCost =Convert.ToDecimal(textBox4.Text);
            if (!GCRUD.vUpdate(cst))
                MessageBox.Show("Update BAŞARISIZ");
            dataGridView1.DataSource = GCRUD.vListele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu go = new MainMenu();
            go.Show();
            this.Hide();
        }
        void ArabaList()
        {
            XmlDocument xmlDocument = new XmlDocument();
            //var olan bir dosya ile calıscaksak eger nesne uretip dosyaya erisim saglamak isteriz.
            DataSet dataSet = new DataSet(); //ado nette ki tablo gibi dsunebiliriz.
            XmlReader xmlfile; //xml dosyamızı verileri okumak için sqldeki sqldata reader gibi calısır.
            xmlfile = XmlReader.Create(@"xmlcrud.xml", new XmlReaderSettings());
            //xml dosyasınan gelen veriyi datasete aktarır.
            dataSet.ReadXml(xmlfile);
            dataGridView1.DataSource = dataSet.Tables[0]; //datasete gelen verileri datagridviewde göstermek isteriz.
            xmlfile.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ArabaList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            XDocument xDocument=XDocument.Load(@"xmlcrud.xml");
            XElement nd = xDocument.Element("vehicles").Elements("vehicle").
                FirstOrDefault(a => a.Element("VehicleId").Value == textBox1.Text);
            if(nd != null)
            {
                nd.SetElementValue("VehicleDriver", textBox2.Text);
                nd.SetElementValue("VehicleType", textBox3.Text);
                nd.SetElementValue("VehicleCost", textBox4.Text);
                xDocument.Save(@"xmlcrud.xml");
                ArabaList();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(@"xmlcrud.xml");
            document.Root.Elements().Where(a => a.Element("VehicleId").Value == textBox1.Text).Remove();
            document.Save(@"xmlcrud.xml");
            ArabaList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            XDocument xmlDocument = XDocument.Load(@"xmlcrud.xml");
            xmlDocument.Element("vehicles").Add(new XElement("vehicle", new XElement
                ("VehicleId", textBox1.Text),
               new XElement("VehicleDriver", textBox2.Text),
               new XElement("VehicleType", textBox3.Text),
               new XElement("VehicleCost", textBox4.Text)
                ));
            xmlDocument.Save(@"xmlcrud.xml");
            ArabaList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["VehicleId"].Value.ToString();
            textBox2.Text = satir.Cells["VehicleDriver"].Value.ToString();
            textBox3.Text = satir.Cells["VehicleType"].Value.ToString();
            textBox4.Text = satir.Cells["VehicleCost"].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vehicle cmd = new vehicle();
            cmd.VehicleDriver = textBox6.Text;
            dataGridView1.DataSource = GCRUD.VehicleSearch(cmd);
        }
    }
}
