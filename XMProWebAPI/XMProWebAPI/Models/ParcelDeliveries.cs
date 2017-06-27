using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMProWebAPI.Models
{
    public class ParcelDeliveries
    {
        [Key]
        public Int64 ParcelDeliveryID { get; set; }
        public Int64 ParcelID { get; set; }
        public Int64 DeliveryServiceRouteID { get; set; }
        public string RouteInstructions { get; set; }//MaxLength="250" />
        public Int32 ParcelDeliverySort { get; set; }
    }
}