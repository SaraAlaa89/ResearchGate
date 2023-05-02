using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResearchGateProject.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string adderss { get; set; }
        public int age { get; set; }
        public string university { get; set; }
        public string department { get; set; }
        public string phoneNumber { get; set; }
        public string image { get; set; }
        public int role { get; set; }
    }
}