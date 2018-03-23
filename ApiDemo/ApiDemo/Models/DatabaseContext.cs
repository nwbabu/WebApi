using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ApiDemo.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
        }

        public DbSet<RegisterUser> RegisterUser { get; set; }
        public DbSet<RegisterCompany> RegisterCompany { get; set; }
        public DbSet<ClientKeys> ClientKeys { get; set; }
        public DbSet<TokensManager> TokensManager { get; set; }
    }
}