using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class customer
    {
        public int CustomerId { get; set; }
        public string CustomerNameSurname { get; set;}
        public string CustomerAdress { get; set;}
        public string CustomerPayment { get; set;}
        public int EmployeeId { get; set; }
    }
}
