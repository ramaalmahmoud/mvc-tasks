using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _18_9_2024.Models;

namespace _18_9_2024.Controllers
{
    public class StudentDetailsController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();

        // GET: StudentDetails
        public ActionResult Index()
        {
            var studentDetails = db.StudentDetails.Include(s => s.Student);
            return View(studentDetails.ToList());
        }

        // GET: StudentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            if (studentDetails == null)
            {
                return HttpNotFound();
            }
            return View(studentDetails);
        }

        // GET: StudentDetails/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name");
            return View();
        }

        // POST: StudentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDetails studentDetails)
        {
            if (ModelState.IsValid)
            {
                db.StudentDetails.Add(studentDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", studentDetails.StudentId);
            return View(studentDetails);
        }

        // GET: StudentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            if (studentDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", studentDetails.StudentId);
            return View(studentDetails);
        }

        // POST: StudentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FatherName,Phone")] StudentDetails studentDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", studentDetails.StudentId);
            return View(studentDetails);
        }

        // GET: StudentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            if (studentDetails == null)
            {
                return HttpNotFound();
            }
            return View(studentDetails);
        }

        // POST: StudentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            db.StudentDetails.Remove(studentDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
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
