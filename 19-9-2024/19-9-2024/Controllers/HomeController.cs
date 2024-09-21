using _19_9_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19_9_2024.Controllers
{
    public class HomeController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(User user)
        {

            var r = db.Users.Where(model => model.Username == user.Username && model.Password == user.Password).FirstOrDefault();


            if (r != null)
            {
                Session["is_login"] = true;
                HttpCookie authCookie = new HttpCookie("UserCookie");
                authCookie.Values["UserId"] = r.ID.ToString();
                authCookie.Values["Username"] = r.Username;

               
                Response.Cookies.Add(authCookie);

                return View("Index");
            }
            else
            {
                ViewBag.LogMsg = ("<script> alert('Invalid Username or Password  ') </script>");
            }
            return View();

        }
    }
}