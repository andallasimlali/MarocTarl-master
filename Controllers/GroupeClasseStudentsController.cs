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
    public class GroupeClasseStudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GroupeClasseStudents
        public ActionResult Index()
        {
            var groupeClasseStudents = db.GroupeClasseStudents.Include(g => g.ClasseStudent).Include(g => g.Groupe);
            return View(groupeClasseStudents.ToList());
        }

        // GET: GroupeClasseStudents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupeClasseStudent groupeClasseStudent = db.GroupeClasseStudents.Find(id);
            if (groupeClasseStudent == null)
            {
                return HttpNotFound();
            }
            return View(groupeClasseStudent);
        }

        // GET: GroupeClasseStudents/Create
        public ActionResult Create()
        {
            ViewBag.ClasseStudentId = new SelectList(db.ClasseStudents, "Id", "Id");
            ViewBag.GroupeId = new SelectList(db.Groupes, "Id", "Name");
            return View();
        }

        // POST: GroupeClasseStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupeId,ClasseStudentId")] GroupeClasseStudent groupeClasseStudent)
        {
            if (ModelState.IsValid)
            {
                groupeClasseStudent.Id = Guid.NewGuid();
                db.GroupeClasseStudents.Add(groupeClasseStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseStudentId = new SelectList(db.ClasseStudents, "Id", "Id", groupeClasseStudent.ClasseStudentId);
            ViewBag.GroupeId = new SelectList(db.Groupes, "Id", "Name", groupeClasseStudent.GroupeId);
            return View(groupeClasseStudent);
        }

        // GET: GroupeClasseStudents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupeClasseStudent groupeClasseStudent = db.GroupeClasseStudents.Find(id);
            if (groupeClasseStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseStudentId = new SelectList(db.ClasseStudents, "Id", "Id", groupeClasseStudent.ClasseStudentId);
            ViewBag.GroupeId = new SelectList(db.Groupes, "Id", "Name", groupeClasseStudent.GroupeId);
            return View(groupeClasseStudent);
        }

        // POST: GroupeClasseStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupeId,ClasseStudentId")] GroupeClasseStudent groupeClasseStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupeClasseStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseStudentId = new SelectList(db.ClasseStudents, "Id", "Id", groupeClasseStudent.ClasseStudentId);
            ViewBag.GroupeId = new SelectList(db.Groupes, "Id", "Name", groupeClasseStudent.GroupeId);
            return View(groupeClasseStudent);
        }

        // GET: GroupeClasseStudents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupeClasseStudent groupeClasseStudent = db.GroupeClasseStudents.Find(id);
            if (groupeClasseStudent == null)
            {
                return HttpNotFound();
            }
            return View(groupeClasseStudent);
        }

        // POST: GroupeClasseStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GroupeClasseStudent groupeClasseStudent = db.GroupeClasseStudents.Find(id);
            db.GroupeClasseStudents.Remove(groupeClasseStudent);
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
