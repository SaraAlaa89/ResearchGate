using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
    public class UserController : Controller,Modify
    {
        Dbcontext DB = new Dbcontext();
        // GET: User
        public ActionResult Index()
        {
            return View("Index");
        }
        public List<Paper> GetAllPapers(int id)
        {
           
            List<Paper> papers = new List<Paper>();
            papers = (from data in DB.papers
                      where (data.AuthorID==id)
                      select data).ToList();
            return papers;
        }
        public void CreateSeasion(User user)
        {
            Session["email"] = user.email;
            Session["password"] = user.password;
            Session["ID"] = user.ID;
            Session["Name"] = user.Name;
            Session["phoneNumber"] = user.phoneNumber;
            Session["role"] = user.role;
            Session["university"] = user.university;
            Session["image"] = user.image;
            Session["department"] = user.department;
            Session["adderss"] = user.adderss;
            Session["age"] = user.age;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
      
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            User user = new User();
            user = (from data in DB.users
                    where (data.email == loginModel.email && data.password == loginModel.password)
                    select data).FirstOrDefault();
            if (user != null)
            {
                CreateSeasion(user);
                ViewBag.papers = GetAllPapers(user.ID);
                return PartialView("ViewProfile",GetAllPapers(user.ID));               
            }             
            else
                return View("Login");
        }
        [HttpGet]
        public ActionResult Register()
        {          
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            DB.users.Add(user);
            DB.SaveChanges();
            return View("Login");
        }
        [HttpGet]
        public ActionResult ViewProfile()
        {
            return PartialView("ViewProfile", GetAllPapers((int)Session["ID"]));
        }
        public User GetUser(int id)
        {
            User currentUser = new User();
          
            currentUser = (from data in DB.users
                           where (data.ID == id)
                           select data).FirstOrDefault();
            return currentUser;
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            return View("EditProfile");
        }

        public ActionResult EditProfile(User user)
        {
            User currentUser = new User();
            int id = (int)Session["ID"];
            currentUser = GetUser(id);
            currentUser.Name = user.Name;
            currentUser.password = user.password;
            currentUser.image = user.image;
            currentUser.phoneNumber = user.phoneNumber;
            currentUser.university = user.university;
            currentUser.email = user.email;
            currentUser.adderss = user.adderss;
            currentUser.department = user.department;
            currentUser.age = user.age;
           
           
            DB.SaveChanges();
            CreateSeasion(currentUser);
            return View("ViewProfile",GetAllPapers((int)Session["ID"]));
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
        }
        public User getUser(int id)
        {
            return DB.users.Single(o => o.ID == id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
           
            var author =getUser(id);
            DB.users.Remove(author);
            DB.SaveChanges();
           
        }


    }
}