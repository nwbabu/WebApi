using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDemo.Models
{
    [Table("ClientKey")]
    public class ClientKeys
    {
        [Key]
        public int ClientKeyID { get; set; }
        public int CompanyID { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public DateTime CreateOn { get; set; }
        public int UserID { get; set; }
    }
}