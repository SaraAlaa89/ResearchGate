using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResearchGateProject.Models
{
    public class Dbcontext:DbContext
    {
        public Dbcontext() : base("DBconnection")
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Paper> papers { get; set; }
        public DbSet<Catagory> catagories { get; set; }
        public DbSet<Comment> comments { get; set; }
    }
}