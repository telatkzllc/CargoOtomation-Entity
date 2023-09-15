using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class shipment
    {
        public int ShipmentId { get; set; }
        public string ShipmentStart { get; set; }
        public string ShipmentEnd { get; set; }
        public int ShipmentKm { get; set; }
        public decimal ShipmentCost { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

    }
}
