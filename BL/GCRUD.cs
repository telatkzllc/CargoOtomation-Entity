using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BL
{
    public class GCRUD
    {
        public static DataTable cListele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("cusList", Tools.baglanti);
            adp.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static DataTable eListele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("emList", Tools.baglanti);
            adp.SelectCommand.CommandType=System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static DataTable vListele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("vehList", Tools.baglanti);
            adp.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static DataTable sListele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("shipList", Tools.baglanti);
            adp.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool lgn(loginn loginn)
        {
            SqlCommand sqlCommand = new SqlCommand("kargogiris", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
               ("@userrId", loginn.userrId);
            sqlCommand.Parameters.AddWithValue
               ("@passwordd", loginn.passwordd);
            return Tools.ConnectSet(sqlCommand);
        }
        public static bool cDelete(customer Cstmr) //1 FK İLE BAGLI OLDUGU İÇİN SİLİNEMİYOR.
        {
            SqlCommand sqlCommand = new SqlCommand("cusDel", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
               ("@CustomerID", Cstmr.CustomerId);
            return Tools.ConnectSet(sqlCommand);
        }
        public static bool eDelete(employee emp)
        {
            SqlCommand sqlCommand = new SqlCommand("emDel", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
               ("@EmployeeId", emp.EmployeeId);
            return Tools.ConnectSet(sqlCommand);
        }
        public static bool vDelete(vehicle vehicle)
        {
            SqlCommand sqlCommand = new SqlCommand("vehDel", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
               ("@VehicleId", vehicle.VehicleId);
            return Tools.ConnectSet(sqlCommand);
        }
        public static bool sDelete(shipment shp)
        {
            SqlCommand sqlCommand = new SqlCommand("shipDel", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue
               ("@shipmentId", shp.ShipmentId);
            return Tools.ConnectSet(sqlCommand);
        }
        public static bool cAdd(customer Cstmr)
        {
            SqlCommand sqlCommand = new SqlCommand("cusAdd", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue
                ("@CustomerNameSurname", Cstmr.CustomerNameSurname);
            sqlCommand.Parameters.AddWithValue
                ("@CustomerAdress", Cstmr.CustomerAdress);
            sqlCommand.Parameters.AddWithValue
                ("@CustomerPayment", Cstmr.CustomerPayment);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeId", Cstmr.EmployeeId);

            return Tools.ConnectSet(sqlCommand);
        }
        public static bool sAdd(shipment shp)
        {
            SqlCommand sqlCommand = new SqlCommand("shipAdd", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue
                ("@ShipmentStart", shp.ShipmentStart);
            sqlCommand.Parameters.AddWithValue
                ("@ShipmentEnd", shp.ShipmentEnd);
            sqlCommand.Parameters.AddWithValue
                ("@ShipmentCost", shp.ShipmentCost);
            sqlCommand.Parameters.AddWithValue
                ("@ShipmentKm", shp.ShipmentKm);
            sqlCommand.Parameters.AddWithValue
                ("@VehicleId", shp.VehicleId);
            sqlCommand.Parameters.AddWithValue
              ("@CustomerId", shp.CustomerId);
            return Tools.ConnectSet(sqlCommand);
        }
        public static bool vAdd(vehicle vehicle)
        {
            SqlCommand sqlCommand = new SqlCommand("vehAdd", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue
                ("@VehicleDriver", vehicle.VehicleDriver);
            sqlCommand.Parameters.AddWithValue
                ("@VehicleType", vehicle.VehicleType);
            sqlCommand.Parameters.AddWithValue
                ("@VehicleCost", vehicle.VehicleCost);
            return Tools.ConnectSet(sqlCommand);
        }
        public static bool eAdd(employee employee)
        {
            SqlCommand sqlCommand = new SqlCommand("emAdd", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeNameSurname", employee.EmployeeNameSurname);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeRank", employee.EmployeeRank);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeePhone", employee.EmployeePhone);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeSalary", employee.EmployeeSalary);

            return Tools.ConnectSet(sqlCommand);
        }
        public static bool cUpdate(customer Cstmr)
        {
            SqlCommand sqlCommand = new SqlCommand("cusUpdate", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
                ("@CustomerId", Cstmr.CustomerId);
            sqlCommand.Parameters.AddWithValue
                ("@CustomerNameSurname", Cstmr.CustomerNameSurname);
            sqlCommand.Parameters.AddWithValue
                ("@CustomerAdress", Cstmr.CustomerAdress);
            sqlCommand.Parameters.AddWithValue
                ("@CustomerPayment", Cstmr.CustomerPayment);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeId", Cstmr.EmployeeId);

            return Tools.ConnectSet(sqlCommand);
        }
        public static bool vUpdate(vehicle vehicle)
        {
            SqlCommand sqlCommand = new SqlCommand("vehUpdate", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
                ("@VehicleId",vehicle.VehicleId);
            sqlCommand.Parameters.AddWithValue
                ("@VehicleDriver", vehicle.VehicleDriver);
            sqlCommand.Parameters.AddWithValue
                ("@VehicleType", vehicle.VehicleType);
            sqlCommand.Parameters.AddWithValue
                ("@VehicleCost", vehicle.VehicleCost);

            return Tools.ConnectSet(sqlCommand);
        }
        public static bool eUpdate(employee emp)
        {
            SqlCommand sqlCommand = new SqlCommand("emUpdate", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
                ("@EmployeeId", emp.EmployeeId);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeNameSurname", emp.EmployeeNameSurname);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeRank", emp.EmployeeRank);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeePhone", emp.EmployeePhone);
            sqlCommand.Parameters.AddWithValue
                ("@EmployeeSalary", emp.EmployeeSalary);

            return Tools.ConnectSet(sqlCommand);
        }
        public static bool sUpdate(shipment shp)
        {
            SqlCommand sqlCommand = new SqlCommand("shipUpdate", Tools.baglanti);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue
              ("@shipmentId", shp.ShipmentId);
            sqlCommand.Parameters.AddWithValue
               ("@shipmentStart", shp.ShipmentStart);
            sqlCommand.Parameters.AddWithValue
                ("@shipmentEnd", shp.ShipmentEnd);
            sqlCommand.Parameters.AddWithValue
              ("@shipmentKm", shp.ShipmentKm);
            sqlCommand.Parameters.AddWithValue
                ("@shipmentCost", shp.ShipmentCost);
            sqlCommand.Parameters.AddWithValue
                ("@vehicleId", shp.VehicleId);
            sqlCommand.Parameters.AddWithValue
              ("@customerId", shp.CustomerId);

            return Tools.ConnectSet(sqlCommand);
        }
        public static DataTable CustomerSearch(customer customer)
        {
            SqlCommand cmd = new SqlCommand("csearch", Tools.baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerNameSurname", customer.CustomerNameSurname);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable VehicleSearch(vehicle vhc)
        {
            SqlCommand cmd = new SqlCommand("vsearch", Tools.baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VehicleDriver", vhc.VehicleDriver);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);   
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable EmployeeSearch(employee emp)
        {
            SqlCommand cmd = new SqlCommand("esearch", Tools.baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeNameSurname", emp.EmployeeNameSurname);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
