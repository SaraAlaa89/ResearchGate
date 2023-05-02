using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResearchGateProject.Models
{
    public class Author:User
    {
        public List<Paper> papers { get; set; }
    }
}