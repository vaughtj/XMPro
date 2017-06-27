using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XMProWebAPI.Models
{
    public class ParcelContext : DbContext
    {
        public ParcelContext() 
                : base("name=ParcelContext")
        {
        }
        public DbSet<Parcels> Parcels { get; set; }
        public DbSet<ParcelDeliveries> ParcelDeliveries { get; set; }
    }
}