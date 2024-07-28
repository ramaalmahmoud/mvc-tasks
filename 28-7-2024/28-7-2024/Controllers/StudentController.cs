using _28_7_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _28_7_2024.Controllers
{
    public class StudentController : Controller
    {
        
        // GET: Student
        public ActionResult Index()
        {
            SchoolEntities db = new SchoolEntities();

            return View(db.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (SchoolEntities db = new SchoolEntities())
            {
                return View(db.Students.Where(x => x.STUDENTID==id).FirstOrDefault());
            }
               
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                using(SchoolEntities db = new SchoolEntities())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (SchoolEntities db = new SchoolEntities())
            {
                return View(db.Students.Where(x => x.STUDENTID == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Student student)
        {
            try
            {
                // TODO: Add update logic here
                using (SchoolEntities db = new SchoolEntities())
                {
                    db.Entry(student).State=EntityState.Modified;
                db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (SchoolEntities db = new SchoolEntities())
            {
                return View(db.Students.Where(x => x.STUDENTID == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                // TODO: Add delete logic here
                using (SchoolEntities db = new SchoolEntities())
                {
                    student=db.Students.Where(x => x.STUDENTID == id).FirstOrDefault();
                    db.Students.Remove(student);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
