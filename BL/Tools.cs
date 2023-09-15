using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using DAL;

namespace BL
{
    public class Tools
    {
        public static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings
           ["kargo"].ToString());

        public static bool ConnectSet(SqlCommand command)
        {
            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();
                return command.ExecuteNonQuery() > 0; //0 dan büyük ise true olarak algılar ve onu döndürür.
            }
            catch
            {
                return false;
            }
            finally
            {
                if (command.Connection.State != System.Data.ConnectionState.Closed)
                    command.Connection.Close();
            }

        }
    }
}
