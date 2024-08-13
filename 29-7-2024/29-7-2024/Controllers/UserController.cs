using _29_7_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _29_7_2024.Controllers
{

    public class UserController : Controller
    {
        private UsersEntities db = new UsersEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {

            var r = db.Users.Where(model => model.Email == user.Email && model.Password == user.Password).FirstOrDefault();


            if (r != null)
            {
                Session["is_login"] = true;
                HttpCookie authCookie = new HttpCookie("UserCookie");
                authCookie.Values["UserId"] = r.Id.ToString();
                authCookie.Values["Username"] = r.Name;

                authCookie.Values["Image"] = r.Image;
                Response.Cookies.Add(authCookie);

                return View("Index");
            }
            else
            {
                ViewBag.LogMsg = ("<script> alert('error') </script>");
            }
            return View();

        }

        // GET: User/Details/5
        public ActionResult Details()
        {
            if (Request.Cookies["UserCookie"] != null)
            {
                int userId = int.Parse(Request.Cookies["UserCookie"]["UserId"]);
                return View(db.Users.Where(x => x.Id == userId).FirstOrDefault());

            }
            return RedirectToAction("Index", "Login");




        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                db.Users.Add(user);
                db.SaveChanges();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            Session["Image"] = db.Users.Find(id).Image;
            return View(db.Users.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: User/Edit/5


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password")] User user, HttpPostedFileBase upload)
        {
            string x = Session["Image"].ToString();

            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Content/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Images/"));
                }

                upload.SaveAs(path);
                user.Image = fileName;
            }

           else if (upload == null)
            {
               var fileName = Path.GetFileName(x);
                user.Image = fileName;

            }


            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string oldPassword, string newPassword, [Bind(Include = "password")] User user)
        {
            int userId = int.Parse(Request.Cookies["UserCookie"]["UserId"]);
            var userInDb = db.Users.Find(userId);
            if (userInDb.Password != oldPassword)
            {

                return View(user); // Return the view with the current user data
            }
             else if(newPassword!=null&& newPassword!="")
            {
                userInDb.Password = newPassword;
            }
            db.SaveChanges();
            return RedirectToAction("Details", new { id = userInDb.Id });

        }
        public ActionResult Logout()
        {
            Session["is_login"] = false;

            return RedirectToAction("Login", "User");
        }
    }
}