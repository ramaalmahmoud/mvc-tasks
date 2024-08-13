using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace _13_8_2024.Controllers
{
    
    public class HomeController : Controller
    {
        private static List<dynamic> products = new List<dynamic>();
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
        public ActionResult Admin()
        {
        

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(FormCollection form)
        {
            //var products = Session["Products"] as List<string[]> ?? new List<string[]>();
            //var product = new string[]{ form[" Name"],  form["Price"], form["Image"] };
            //products.Add(product);
            //Session["Products"] = products;
            //return RedirectToAction("Product

            //var product = new string[] { form[" Name"], form["Price"], form["Image"] };
            //products.Add(product);
            //Session["Products"]= products;
            //return RedirectToAction("Product");
            
            var product = new dynamic []{  form["Name"], form["Price"],  form["Image"] };

         
            var products = Session["Products"] as List<dynamic> ?? new List<dynamic>();

           
            products.Add(product);

         
            Session["Products"] = products;

            return RedirectToAction("Product");

        }
        public ActionResult Product()
        {
            //var products = Session["Products"] as List<string[]> ?? new List<string[]>();


            //return View(product);
            //return View(products);
            var products = Session["Products"] as List<dynamic> ?? new List<dynamic>();
            return View(products);
        }
    }
}