using BL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Kargootomasyon
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        void EmployeeList()
        {
            XmlDocument xmlDocument = new XmlDocument();
            //var olan bir dosya ile calıscaksak eger nesne uretip dosyaya erisim saglamak isteriz.
            DataSet dataSet = new DataSet(); //ado nette ki tablo gibi dsunebiliriz.
            XmlReader xmlfile; //xml dosyamızı verileri okumak için sqldeki sqldata reader gibi calısır.
            xmlfile = XmlReader.Create(@"employeecrudxml.xml", new XmlReaderSettings());
            //xml dosyasınan gelen veriyi datasete aktarır.
            dataSet.ReadXml(xmlfile);
            dataGridView1.DataSource = dataSet.Tables[0]; //datasete gelen verileri datagridviewde göstermek isteriz.
            xmlfile.Close();

        }
        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GCRUD.eListele();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            employee employee = new employee();
            employee.EmployeeId = Convert.ToInt32(textBox1.Text);
            if (!GCRUD.eDelete(employee))
                MessageBox.Show("SİLME BAŞARISIZ");
            dataGridView1.DataSource = GCRUD.eListele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            employee cst = new employee();
            cst.EmployeeId = int.Parse(textBox1.Text);
            cst.EmployeeNameSurname = textBox2.Text;
            cst.EmployeeRank = (textBox3.Text);
            cst.EmployeePhone = textBox4.Text;
            cst.EmployeeSalary = Convert.ToDecimal(textBox5.Text);
            GCRUD.eAdd(cst);
            dataGridView1.DataSource = GCRUD.eListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee cst = new employee();
            cst.EmployeeId = Convert.ToInt32(textBox1.Text);
            cst.EmployeeNameSurname = textBox2.Text;
            cst.EmployeeRank = textBox3.Text;
            cst.EmployeePhone = textBox4.Text;
            cst.EmployeeSalary = Convert.ToDecimal(textBox5.Text);
            if (!GCRUD.eUpdate(cst))
                MessageBox.Show("Update BAŞARISIZ");
            dataGridView1.DataSource = GCRUD.eListele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu go = new MainMenu();
            go.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            XDocument xDocument = XDocument.Load(@"employeecrudxml.xml");
            XElement nd = xDocument.Element("employees").Elements("employee").
                FirstOrDefault(a => a.Element("employeeıd").Value == textBox1.Text);
            if (nd != null)
            {
                nd.SetElementValue("employeename", textBox2.Text);
                nd.SetElementValue("employeerank", textBox3.Text);
                nd.SetElementValue("employeephone", textBox4.Text);
                nd.SetElementValue("employeesalary", textBox5.Text);
                xDocument.Save(@"employeecrudxml.xml");
                EmployeeList();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(@"employeecrudxml.xml");
            document.Root.Elements().Where(a => a.Element("employeeıd").Value == textBox1.Text).Remove();
            document.Save(@"employeecrudxml.xml");
            EmployeeList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            XDocument xmlDocument = XDocument.Load(@"employeecrudxml.xml");
            xmlDocument.Element("employees").Add(new XElement("employee", new XElement
                ("employeeıd", textBox1.Text),
               new XElement("employeename", textBox2.Text),
               new XElement("employeerank", textBox3.Text),
               new XElement("employeephone", textBox4.Text),
                new XElement("employeesalary", textBox5.Text)
                ));
            xmlDocument.Save(@"employeecrudxml.xml");
            EmployeeList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            employee cmd = new employee();
            cmd.EmployeeNameSurname = textBox6.Text;
            dataGridView1.DataSource = GCRUD.EmployeeSearch(cmd);
        }
    }
}
