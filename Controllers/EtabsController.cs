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
    public class EtabsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Etabs
        public ActionResult Index(Guid id) // = DirectionId
        {
            var etabs = db.Etabs.Where(x=>x.DirectionId== id).Include(e => e.Direction);
            ViewBag.id = id;
            return View(etabs.ToList());
        }

        // GET: Etabs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etab etab = db.Etabs.Find(id);
            if (etab == null)
            {
                return HttpNotFound();
            }
            return View(etab);
        }

        // GET: Etabs/Create
        public ActionResult Create(Guid id) // = DirectionId
        {
            Etab e = new Etab();
            e.DirectionId = id;
            return View(e);
        }

        // POST: Etabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DirectionId")] Etab etab)
        {
            if (ModelState.IsValid)
            {
                etab.Id = Guid.NewGuid();
                db.Etabs.Add(etab);
                db.SaveChanges();
                return RedirectToAction("Index",new { id = etab.DirectionId});
            }

            ViewBag.DirectionId = new SelectList(db.Directions, "Id", "Name", etab.DirectionId);
            return View(etab);
        }

        // GET: Etabs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etab etab = db.Etabs.Find(id);
            if (etab == null)
            {
                return HttpNotFound();
            }

            return View(etab);
        }

        // POST: Etabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DirectionId")] Etab etab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = etab.DirectionId });
            }

            return View(etab);
        }

        // GET: Etabs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etab etab = db.Etabs.Find(id);
            if (etab == null)
            {
                return HttpNotFound();
            }
            return View(etab);
        }

        // POST: Etabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Etab etab = db.Etabs.Find(id);
            var DirectionId = etab.DirectionId;
            db.Etabs.Remove(etab);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = DirectionId });
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
