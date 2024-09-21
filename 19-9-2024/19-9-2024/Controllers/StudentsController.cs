using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _19_9_2024.Models;

namespace _19_9_2024.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Classes);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create(int classId)
        {
            // Store the classId in the ViewBag to use in the form
            ViewBag.ClassId = classId;

            return View();
        }


        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentName,StudentAge")] Student student, int classId)
        {
            if (ModelState.IsValid)
            {
                // Assign the classId directly to the student object
                student.ClassId = classId;

                db.Students.Add(student);
                db.SaveChanges();

                return RedirectToAction("Details", "Classes", new { id = student.ClassId });
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id, int classId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = classId;
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentName,StudentAge,ClassId")] Student student, int classId)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ClassId = classId;

                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Classes", new { id = student.ClassId });
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Details", "Classes", new { id = student.ClassId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
