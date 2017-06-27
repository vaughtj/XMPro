using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMProApp.Models
{
    public class Parcels : BindableBase
    {
        public Int64 ParcelID { get; set; }
        public Int64 DropOffStoreID { get; set; }

        public string CustomerName { get; set; }

        private string _destinationAddress;
        public string DestinationAddress  { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationST { get; set; }
        public string DestinationZip { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal InsuranceWorth { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public decimal Weight { get; set; }

        public bool shouldSave { get; set; }



    }

    public class ODATAObject
    {
        public List<Parcels> value { get; set; }
    }
}
