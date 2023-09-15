using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;  //3 satır ekle.
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kargootomasyon
{
    public partial class xml : Form
    {
        public xml()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Customers");

            SqlConnection con = new SqlConnection("Server=.;Database=Kargo;Integrated Security=true;");
            SqlCommand command = new SqlCommand("select * from Customer", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                XmlElement customer = xmlDocument.CreateElement("customer");
                XmlAttribute adsoyad = xmlDocument.CreateAttribute("CustomerNameSurname");
                adsoyad.Value = reader["CustomerNameSurname"].ToString();

                XmlAttribute sehir = xmlDocument.CreateAttribute("CustomerAdress");
                sehir.Value = reader["CustomerAdress"].ToString();

                XmlAttribute pay = xmlDocument.CreateAttribute("CustomerPayment"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                pay.Value = reader["CustomerPayment"].ToString();

                XmlAttribute emp = xmlDocument.CreateAttribute("EmployeeId"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                emp.Value = reader["EmployeeId"].ToString();

                customer.Attributes.Append(adsoyad); //yazdırmak için vardır.
                customer.Attributes.Append(sehir);
                customer.Attributes.Append(pay);
                customer.Attributes.Append(emp);
                root.AppendChild(customer); // düğümü ekleyebilmesi için vardır.
            }
            con.Close();
            xmlDocument.AppendChild(root);
            xmlDocument.Save("veri.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Shipments");

            SqlConnection con = new SqlConnection("Server=.;Database=Kargo;Integrated Security=true;");
            SqlCommand command = new SqlCommand("select * from Shipment", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                XmlElement shipment = xmlDocument.CreateElement("shipment");
                XmlAttribute start = xmlDocument.CreateAttribute("ShipmentStart");
                start.Value = reader["ShipmentStart"].ToString();

                XmlAttribute end = xmlDocument.CreateAttribute("ShipmentEnd");
                end.Value = reader["ShipmentEnd"].ToString();

                XmlAttribute km = xmlDocument.CreateAttribute("ShipmentKm"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                km.Value = reader["ShipmentKm"].ToString();

                XmlAttribute cost = xmlDocument.CreateAttribute("ShipmentCost"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                cost.Value = reader["ShipmentCost"].ToString();

                XmlAttribute vehicle = xmlDocument.CreateAttribute("VehicleId"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                vehicle.Value = reader["VehicleId"].ToString();

                XmlAttribute ıd = xmlDocument.CreateAttribute("CustomerId"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                ıd.Value = reader["CustomerId"].ToString();

                shipment.Attributes.Append(start); //yazdırmak için vardır.
                shipment.Attributes.Append(end);
                shipment.Attributes.Append(km);
                shipment.Attributes.Append(cost);
                shipment.Attributes.Append(vehicle);
                shipment.Attributes.Append(ıd);
                root.AppendChild(shipment); // düğümü ekleyebilmesi için vardır.
            }
            xmlDocument.AppendChild(root);
            xmlDocument.Save("veri1.xml");
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Employees");

            SqlConnection con = new SqlConnection("Server=.;Database=Kargo;Integrated Security=true;");
            SqlCommand command = new SqlCommand("select * from Employee", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                XmlElement employee = xmlDocument.CreateElement("employee");
                XmlAttribute adsoyad = xmlDocument.CreateAttribute("EmployeeNameSurname");
                adsoyad.Value = reader["EmployeeNameSurname"].ToString();

                XmlAttribute rnk = xmlDocument.CreateAttribute("EmployeeRank");
                rnk.Value = reader["EmployeeRank"].ToString();

                XmlAttribute phone = xmlDocument.CreateAttribute("EmployeePhone"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                phone.Value = reader["EmployeePhone"].ToString();

                XmlAttribute salary = xmlDocument.CreateAttribute("EmployeeSalary"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                salary.Value = reader["EmployeeSalary"].ToString();

                employee.Attributes.Append(adsoyad); //yazdırmak için vardır.
                employee.Attributes.Append(rnk);
                employee.Attributes.Append(phone);
                employee.Attributes.Append(salary);
                root.AppendChild(employee); // düğümü ekleyebilmesi için vardır.
            }
            con.Close();
            xmlDocument.AppendChild(root);
            string xmlname = textBox1.Text;
            xmlDocument.Save(xmlname);
            con.Close();
            //string xmlname = textBox1.Text;
            //xml.Save(xmlname);
            //coon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Vehicles");

            SqlConnection con = new SqlConnection("Server=.;Database=Kargo;Integrated Security=true;");
            SqlCommand command = new SqlCommand("select * from Vehicle", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                XmlElement vehicle = xmlDocument.CreateElement("vehicle");
                XmlAttribute driver = xmlDocument.CreateAttribute("VehicleDriver");
                driver.Value = reader["VehicleDriver"].ToString();

                XmlAttribute type = xmlDocument.CreateAttribute("VehicleType");
                type.Value = reader["VehicleType"].ToString();

                XmlAttribute cost = xmlDocument.CreateAttribute("Vehiclecost"); //Tablodakininbirebir aynıısı olması lazım. alttakinin.
                cost.Value = reader["VehicleCost"].ToString();


                vehicle.Attributes.Append(driver); //yazdırmak için vardır.
                vehicle.Attributes.Append(type);
                vehicle.Attributes.Append(cost);
                root.AppendChild(vehicle); // düğümü ekleyebilmesi için vardır.
            }
            con.Close();
            xmlDocument.AppendChild(root);
            xmlDocument.Save("veri3.xml");
        }
    }
}
