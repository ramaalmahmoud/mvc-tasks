using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace _23_7_2024.Controllers
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

        [HttpGet]
        public ActionResult Contact()
        {
            



            return View();
        }
        [HttpPost]
        public ActionResult show(FormCollection form)
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
            return View();
        }
    }
}