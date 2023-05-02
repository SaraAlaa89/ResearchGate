using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResearchGateProject.Models
{
    public class Paper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public bool like { get; set; }
        public bool dislike { get; set; }
        public string header { get; set; }
        public string content { get; set; }
        public DateTime Date { get; set; }
        public List<Comment> comments { get; set; }
        public string catagory { get; set; }
        public int AuthorID { get; set; }
        public int catagoryID { get; set; }


    }
}