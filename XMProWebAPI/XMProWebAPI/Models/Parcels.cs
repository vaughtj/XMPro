using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMProWebAPI.Models
{
    public class Parcels
    {
        [Key]
        public Int64 ParcelID { get; set; }
        public Int64 DropOffStoreID { get; set; }
        public string CustomerName { get; set; }
        public string DestinationAddress { get; set; }//" Type="nvarchar" MaxLength="50" />
        public string DestinationCity { get; set; }//" Type="nvarchar" MaxLength="50" />
        public string DestinationST { get; set; }//" Type="nvarchar" MaxLength="2" />
        public string DestinationZip { get; set; }//" Type="nvarchar" MaxLength="10" />
        public DateTime DeliveryDate { get; set; }//" Type="datetime" />
        public decimal InsuranceWorth { get; set; }//" Type="decimal" Precision="18" Scale="2" />
        public string Height { get; set; }//" Type="nvarchar" MaxLength="4" />
        public string Width { get; set; }//" Type="nvarchar" MaxLength="4" />
        public string Length { get; set; }//" Type="nvarchar" MaxLength="4" />
        public decimal Weight { get; set; }//" Type="decimal" Precision="18" Scale="2" />
    }
}