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
    public class DirectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Directions
        public ActionResult Index(Guid id) // = Academie Id
        {
            var directions = db.Directions.Where(x=>x.AcademieId==id).Include(d => d.Academie);
            ViewBag.id = id;

            return View(directions.ToList());
        }

        // GET: Directions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            return View(direction);
        }

        // GET: Directions/Create
        public ActionResult Create(Guid id)
        {
            Direction d = new Direction();
            d.AcademieId = id;

            return View(d);
        }

        // POST: Directions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AcademieId")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                direction.Id = Guid.NewGuid();
                db.Directions.Add(direction);
                db.SaveChanges();
                return RedirectToAction("Index", "Directions", new { id = direction.AcademieId});
            }


            return View(direction);
        }

        // GET: Directions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademieId = new SelectList(db.Academies, "Id", "Name", direction.AcademieId);
            return View(direction);
        }

        // POST: Directions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AcademieId")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Directions", new { id = direction.AcademieId });
            }

            return View(direction);
        }

        // GET: Directions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            return View(direction);
        }

        // POST: Directions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Direction direction = db.Directions.Find(id);
            var AcademieId = direction.AcademieId;
            db.Directions.Remove(direction);
            db.SaveChanges();
            return RedirectToAction("Index", "Directions", new { id = AcademieId });
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
