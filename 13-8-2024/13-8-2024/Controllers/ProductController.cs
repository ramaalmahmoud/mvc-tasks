using _13_8_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_8_2024.Controllers
{
    public class ProductController : Controller
    {
        private static List<Class1> products = new List<Class1>();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(Class1 product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Product");
            }
            return View(product);
        }
        public ActionResult Product()
        {
            return View(products);
        }


    }
}