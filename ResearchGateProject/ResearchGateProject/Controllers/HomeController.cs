using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResearchGateProject.Controllers
{
    public class HomeController : Controller
    {
        Dbcontext DB = new Dbcontext();
        public ActionResult Index()
        {
            return View();
        }
        List<Paper> GetAllPapers(int id)
        {
            List<Paper> papers = new List<Paper>();
            papers = (from data in DB.papers
                      where (data.AuthorID != id)
                      select data).ToList();
            return papers;
        }
        [HttpGet]
        public ActionResult ViewHome()
        {
            return PartialView("ViewHome",GetAllPapers((int)Session["ID"]));
        }
        public void GetSpams(ref List<User>users)
        {
            List<User> spams = new List<User>();
            foreach (var item in users)
            {
                if (item.ID == (int)Session["ID"]) spams.Add(item);
            }
            foreach (var item in spams) users.Remove(item);
        }
        [HttpPost]
        public ActionResult Search(SearchModel search)
        {
            List<User> users = (from data in DB.users
                         where (data.university == search.need ||
                         data.email == search.need || data.Name == search.need )
                         select data).ToList();

            GetSpams(ref users);
             return View(users);
        }
        public Author PutUserIntoAuthor(User user)
        {
            Author author = new Author();
            author.ID = user.ID;
            author.Name = user.Name;
            author.email = user.email;
            author.password = user.password;
            author.university = user.university;
            author.department = user.department;
            author.adderss = user.adderss;
            author.age = user.age;
            author.image = user.image;
            author.role = user.role;
            author.phoneNumber = user.phoneNumber;
            return author;


       }
       
                  
        [HttpGet]
        public ActionResult OtherProfile(int id)
        {
            User user = new User();
            UserController userController = new UserController();
            user = userController.GetUser(id);
            Author author = new Author();
            author = PutUserIntoAuthor(user);
         
            author.papers = userController.GetAllPapers(user.ID);
          
            return View(author);
        }
    }
}