using BusinessPartnerManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI
{
    public class DataContext : DbContext
    {
        public DataContext() :base("DefaultConnection")
        {

        }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<Policy> Policies { get; set; }
    }
}