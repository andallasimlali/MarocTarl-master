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
    public class ExercicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exercices
        public ActionResult Index(Guid id) // = Palierd
        {
            ViewBag.id = id;

            var exercices = db.Exercices.Where(x=>x.PalierId==id).Include(e => e.Palier);
            return View(exercices.ToList());
        }

        // GET: Exercices/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercices.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // GET: Exercices/Create
        public ActionResult Create(Guid id) // = Palierd
        {
            Exercice e = new Exercice();
            e.PalierId = id;
            return View(e);
        }

        // POST: Exercices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PalierId,Ordre,ShowWithPrevious,Seuil,Description")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                exercice.Id = Guid.NewGuid();
                db.Exercices.Add(exercice);
                db.SaveChanges();
                return RedirectToAction("Index" , new { id=exercice.PalierId });
            }

            return View(exercice);
        }

        // GET: Exercices/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercices.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // POST: Exercices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PalierId,Ordre,ShowWithPrevious,Seuil,Description")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = exercice.PalierId });
            }
            return View(exercice);
        }

        // GET: Exercices/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercices.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // POST: Exercices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Exercice exercice = db.Exercices.Find(id);
            var PalierId = id;
            db.Exercices.Remove(exercice);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = PalierId });
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
