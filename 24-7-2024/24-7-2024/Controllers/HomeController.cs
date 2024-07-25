using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _24_7_2024.Controllers
{
    public class HomeController : Controller
    {
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

        [HttpPost]
        public ActionResult submit(FormCollection form)
        {
            ViewBag.FirstName = form["firstName"];
            ViewBag.age = form["age"];
            string Gender = form["Gender"];
            string radio = "";
            switch (Gender)
            {
                case "Male":
                    radio = "Male";
                    break;
                case "Female":
                    radio = "Female";
                    break;

            }

            ViewBag.radio = radio;


            string Country = form["Country"];
            string drop = "";
            switch (Country)
            {
                case "Selected":
                    drop = "";
                    break;

                case "Jordan":
                    drop = "Jordan";
                    break;

                case "Palastine":
                    drop = "Palastine";
                    break;

                case "Egypt":
                    drop = "Egypt";
                    break;




            }

            ViewBag.drop = drop;


            return View("Contact");
        }
        public ActionResult send(FormCollection form )
        {
            string[] arr = { "Rama", "ramaoudat151@gmail.com" };
            bool isValid = false;
            ViewBag.name= form["firstName"];
            ViewBag.email=form["Email"];
            for (int i = 0; i < arr.Length - 1; i++) {
                if (arr[i] == ViewBag.name && arr[i+1] == ViewBag.email)
                {
                    ViewBag. isValid = true;
                    Session["UserName"] = form["firstName"];
                    return View("Index");

                }
            }


            return View("Login");
        }
        public ActionResult Login()
        {
            


            return View();
        }
        public ActionResult Logout()
        {
           
            return RedirectToAction("Login", "Home");
        }
    }
}