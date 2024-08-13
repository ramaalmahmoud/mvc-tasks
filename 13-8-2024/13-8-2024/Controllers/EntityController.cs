using _13_8_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_8_2024.Controllers
{

    public class EntityController : Controller
    {
        private RamaEntities db = new RamaEntities();

        // GET: Entity
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Product");
            }
            return View(product);
        }

        public ActionResult Product()
        {
            return View(db.Products);
        }
    }
}