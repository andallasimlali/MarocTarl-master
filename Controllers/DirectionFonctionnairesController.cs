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
    public class DirectionFonctionnairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DirectionFonctionnaires
        public ActionResult Index()
        {
            var directionFonctionnaires = db.DirectionFonctionnaires.Include(d => d.Direction);
            return View(directionFonctionnaires.ToList());
        }

        // GET: DirectionFonctionnaires/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectionFonctionnaire directionFonctionnaire = db.DirectionFonctionnaires.Find(id);
            if (directionFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(directionFonctionnaire);
        }

        // GET: DirectionFonctionnaires/Create
        public ActionResult Create()
        {
            ViewBag.DirectionId = new SelectList(db.Directions, "Id", "Name");
            return View();
        }

        // POST: DirectionFonctionnaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DirectionId,UserId,AnnéeScolaire")] DirectionFonctionnaire directionFonctionnaire)
        {
            if (ModelState.IsValid)
            {
                directionFonctionnaire.Id = Guid.NewGuid();
                db.DirectionFonctionnaires.Add(directionFonctionnaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectionId = new SelectList(db.Directions, "Id", "Name", directionFonctionnaire.DirectionId);
            return View(directionFonctionnaire);
        }

        // GET: DirectionFonctionnaires/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectionFonctionnaire directionFonctionnaire = db.DirectionFonctionnaires.Find(id);
            if (directionFonctionnaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectionId = new SelectList(db.Directions, "Id", "Name", directionFonctionnaire.DirectionId);
            return View(directionFonctionnaire);
        }

        // POST: DirectionFonctionnaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DirectionId,UserId,AnnéeScolaire")] DirectionFonctionnaire directionFonctionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directionFonctionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectionId = new SelectList(db.Directions, "Id", "Name", directionFonctionnaire.DirectionId);
            return View(directionFonctionnaire);
        }

        // GET: DirectionFonctionnaires/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectionFonctionnaire directionFonctionnaire = db.DirectionFonctionnaires.Find(id);
            if (directionFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(directionFonctionnaire);
        }

        // POST: DirectionFonctionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DirectionFonctionnaire directionFonctionnaire = db.DirectionFonctionnaires.Find(id);
            db.DirectionFonctionnaires.Remove(directionFonctionnaire);
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
