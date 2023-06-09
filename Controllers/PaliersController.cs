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
    public class PaliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Paliers
        public ActionResult Index(Guid id)
        {
            var paliers = db.Paliers.Where(x=>x.ExamId==id).Include(p => p.Exam);
            ViewBag.id = id;
            return View(paliers.ToList());
        }

        // GET: Paliers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palier palier = db.Paliers.Find(id);
            if (palier == null)
            {
                return HttpNotFound();
            }
            return View(palier);
        }

        // GET: Paliers/Create
        public ActionResult Create(Guid id) // id= ExamId
        {
            Palier p = new Palier();
            p.ExamId = id;


            return View(p);
        }

        // POST: Paliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamId,Ordre,IsCompetence")] Palier palier)
        {
            if (ModelState.IsValid)
            {
                palier.Id = Guid.NewGuid();
                db.Paliers.Add(palier);
                db.SaveChanges();
                return RedirectToAction("Index" , new { id = palier.ExamId});
            }

            return View(palier);
        }

        // GET: Paliers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palier palier = db.Paliers.Find(id);
            if (palier == null)
            {
                return HttpNotFound();
            }

            return View(palier);
        }

        // POST: Paliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamId,Ordre,IsCompetence")] Palier palier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = palier.ExamId });
            }

            return View(palier);
        }

        // GET: Paliers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palier palier = db.Paliers.Find(id);
            if (palier == null)
            {
                return HttpNotFound();
            }
            return View(palier);
        }

        // POST: Paliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Palier palier = db.Paliers.Find(id);
            var ExamId = palier.ExamId;
            db.Paliers.Remove(palier);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = palier.ExamId });
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
