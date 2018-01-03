using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace UserWebApi.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    public class UserDBContext :DbContext
    {
        public UserDBContext():base("DBCON")
        {
        }
        public DbSet<User> users { get; set; }
    }
}