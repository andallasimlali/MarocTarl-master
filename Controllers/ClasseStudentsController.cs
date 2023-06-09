using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarocTarl.Models;

namespace MarocTarl.Controllers
{
    public class ClasseStudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClasseStudents
        public ActionResult Index()
        {
            var classeStudents = db.ClasseStudents.Include(c => c.Classe);
            return View(classeStudents.ToList());
        }

        // GET: ClasseStudents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasseStudent classeStudent = db.ClasseStudents.Find(id);
            if (classeStudent == null)
            {
                return HttpNotFound();
            }
            return View(classeStudent);
        }

        // GET: ClasseStudents/Create
        public ActionResult Create()
        {
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name");
            return View();
        }

        // POST: ClasseStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClasseId,UserId")] ClasseStudent classeStudent)
        {
            if (ModelState.IsValid)
            {
                classeStudent.Id = Guid.NewGuid();
                db.ClasseStudents.Add(classeStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name", classeStudent.ClasseId);
            return View(classeStudent);
        }

        // GET: ClasseStudents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasseStudent classeStudent = db.ClasseStudents.Find(id);
            if (classeStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name", classeStudent.ClasseId);
            return View(classeStudent);
        }

        // POST: ClasseStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClasseId,UserId")] ClasseStudent classeStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classeStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name", classeStudent.ClasseId);
            return View(classeStudent);
        }

        // GET: ClasseStudents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasseStudent classeStudent = db.ClasseStudents.Find(id);
            if (classeStudent == null)
            {
                return HttpNotFound();
            }
            return View(classeStudent);
        }

        // POST: ClasseStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ClasseStudent classeStudent = db.ClasseStudents.Find(id);
            db.ClasseStudents.Remove(classeStudent);
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
