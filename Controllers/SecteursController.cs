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
    public class SecteursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Secteurs
        public ActionResult Index(Guid Insp) // = inspecteur Id
        {
            var secteurs = db.Secteurs;
            return View(secteurs.ToList());
        }

        // GET: Secteurs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secteur secteur = db.Secteurs.Find(id);
            if (secteur == null)
            {
                return HttpNotFound();
            }
            return View(secteur);
        }

        // GET: Secteurs/Create
        public ActionResult Create()
        {
            ViewBag.DirectionId = new SelectList(db.Directions, "Id", "Name");
            return View();
        }

        // POST: Secteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DirectionId,Name")] Secteur secteur)
        {
            if (ModelState.IsValid)
            {
                secteur.Id = Guid.NewGuid();
                db.Secteurs.Add(secteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectionFonctionnaireId = new SelectList(db.DirectionFonctionnaires, "Id", "Name", secteur.DirectionFonctionnaireId);
            return View(secteur);
        }

        // GET: Secteurs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secteur secteur = db.Secteurs.Find(id);
            if (secteur == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectionFonctionnaireId = new SelectList(db.DirectionFonctionnaires, "Id", "Name", secteur.DirectionFonctionnaireId);
            return View(secteur);
        }

        // POST: Secteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DirectionId,Name")] Secteur secteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectionFonctionnaireId = new SelectList(db.DirectionFonctionnaires, "Id", "Name", secteur.DirectionFonctionnaireId);
            return View(secteur);
        }

        // GET: Secteurs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secteur secteur = db.Secteurs.Find(id);
            if (secteur == null)
            {
                return HttpNotFound();
            }
            return View(secteur);
        }

        // POST: Secteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Secteur secteur = db.Secteurs.Find(id);
            db.Secteurs.Remove(secteur);
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
