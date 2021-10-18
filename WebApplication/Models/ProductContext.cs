using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication.Models
{
    public class ProductContext:DbContext
    {
        public DbSet<ProductMaster> ProductMasters { get; set; }
    }
}