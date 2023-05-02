using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
    public class CommentController : Controller
    {
        Dbcontext DB = new Dbcontext();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        public List<Paper> GetAllPapers()
        {
            int id = (int)Session["ID"];
            List<Paper> papers = new List<Paper>();
            papers = (from data in DB.papers
                      where (data.AuthorID == id)
                      select data).ToList();
            return papers;
        }
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
           
            DB.comments.Add(comment);
            DB.SaveChanges();

            return View("../User/ViewProfile",GetAllPapers());
        }
    }
}