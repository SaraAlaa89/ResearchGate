using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Dbcontext DB = new Dbcontext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewUser(int authorID)
        {

            return View();
        }
        public ActionResult AboutDelet(int state , int id)
        {
            Modify type;
            if (state == 1) type = new PaperController();
            else type = new UserController();
            Delete(type, id);
            UserController userController = new UserController();
            if (state == 1)
                return PartialView("../User/ViewProfile", userController.GetAllPapers((int)Session["ID"]));
            return View("../User/Login");
        }
      
        public ActionResult DeleteReactLike(int paperID)
        {
            Paper paper = new Paper();
            paper = (from data in DB.papers
                     where data.ID == paperID
                     select data).FirstOrDefault();
            paper.like = false;
            DB.SaveChanges();
            return View();
        }
        public ActionResult DeleteReactDislike(int paperID)
        {
            Paper paper = new Paper();
            paper = (from data in DB.papers
                     where data.ID == paperID
                     select data).FirstOrDefault();
            paper.dislike = false;
            DB.SaveChanges();
            return View();
        }
        [HttpGet]
       public void Delete(Modify type , int id)
        {
           
            type.Delete(id);
           
  
        }
     
    }
}