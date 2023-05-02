using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResearchGateProject.Controllers
{
    public class CatagoryController : Controller
    {
        Dbcontext DB = new Dbcontext();
        // GET: Catagory
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCatagory()
        {
            return View("AddCatagory");
        }
        [HttpPost]
        public ActionResult AddCatagory(Catagory catagory)
        {
            DB.catagories.Add(catagory);
            DB.SaveChanges();
            UserController userController = new UserController();
            return PartialView("../User/ViewProfile", userController.GetAllPapers((int)Session["ID"]));
        }
        public ActionResult DeleteCatagory(int catagoryID)
        {
            Catagory catagory = new Catagory();
            catagory = DB.catagories.Find(catagoryID);
            DB.catagories.Remove(catagory);
            DB.SaveChanges();
            return View("Profile");
        }
    }
}