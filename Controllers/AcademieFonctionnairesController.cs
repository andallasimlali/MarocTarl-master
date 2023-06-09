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
    public class AcademieFonctionnairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcademieFonctionnaires
        public ActionResult Index()
        {
            var academieFonctionnaires = db.AcademieFonctionnaires.Include(a => a.Academie);
            return View(academieFonctionnaires.ToList());
        }

        // GET: AcademieFonctionnaires/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademieFonctionnaire academieFonctionnaire = db.AcademieFonctionnaires.Find(id);
            if (academieFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(academieFonctionnaire);
        }

        // GET: AcademieFonctionnaires/Create
        public ActionResult Create()
        {
            ViewBag.AcademieId = new SelectList(db.Academies, "Id", "Name");
            return View();
        }

        // POST: AcademieFonctionnaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AcademieId,UserId,AnnéeSِolaire")] AcademieFonctionnaire academieFonctionnaire)
        {
            if (ModelState.IsValid)
            {
                academieFonctionnaire.Id = Guid.NewGuid();
                db.AcademieFonctionnaires.Add(academieFonctionnaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademieId = new SelectList(db.Academies, "Id", "Name", academieFonctionnaire.AcademieId);
            return View(academieFonctionnaire);
        }

        // GET: AcademieFonctionnaires/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademieFonctionnaire academieFonctionnaire = db.AcademieFonctionnaires.Find(id);
            if (academieFonctionnaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademieId = new SelectList(db.Academies, "Id", "Name", academieFonctionnaire.AcademieId);
            return View(academieFonctionnaire);
        }

        // POST: AcademieFonctionnaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AcademieId,UserId,AnnéeSِolaire")] AcademieFonctionnaire academieFonctionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academieFonctionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademieId = new SelectList(db.Academies, "Id", "Name", academieFonctionnaire.AcademieId);
            return View(academieFonctionnaire);
        }

        // GET: AcademieFonctionnaires/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademieFonctionnaire academieFonctionnaire = db.AcademieFonctionnaires.Find(id);
            if (academieFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(academieFonctionnaire);
        }

        // POST: AcademieFonctionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AcademieFonctionnaire academieFonctionnaire = db.AcademieFonctionnaires.Find(id);
            db.AcademieFonctionnaires.Remove(academieFonctionnaire);
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
