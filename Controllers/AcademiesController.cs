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
    public class AcademiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Academies
        public ActionResult Index(Guid id) // = Ministere Id
        {
            var academies = db.Academies.Where(x=>x.MinistereId==id).Include(a => a.Ministere);
            ViewBag.MinistereId = id;
            return View(academies.ToList());
        }

        // GET: Academies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academie academie = db.Academies.Find(id);
            if (academie == null)
            {
                return HttpNotFound();
            }
            return View(academie);
        }

        // GET: Academies/Create
        public ActionResult Create (Guid id) // = Ministere Id
        {

            Academie a = new Academie();
            a.MinistereId = id; 
            return View(a);
        }

        // POST: Academies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MinistereId")] Academie academie)
        {
            if (ModelState.IsValid)
            {
                academie.Id = Guid.NewGuid();
                db.Academies.Add(academie);
                db.SaveChanges();
                return RedirectToAction("Index", "Academies", new { id = academie.MinistereId });
            }

            ViewBag.MinistereId = new SelectList(db.Ministeres, "Id", "Name", academie.MinistereId);
            return View(academie);
        }

        // GET: Academies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academie academie = db.Academies.Find(id);
            if (academie == null)
            {
                return HttpNotFound();
            }

            return View(academie);
        }

        // POST: Academies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MinistereId")] Academie academie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Academies", new { id = academie.MinistereId });
            }
            ViewBag.MinistereId = new SelectList(db.Ministeres, "Id", "Name", academie.MinistereId);
            return View(academie);
        }

        // GET: Academies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academie academie = db.Academies.Find(id);
            if (academie == null)
            {
                return HttpNotFound();
            }
            return View(academie);
        }

        // POST: Academies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Academie academie = db.Academies.Find(id);
            var MinistereId = academie.MinistereId;
            db.Academies.Remove(academie);
            db.SaveChanges();
            return RedirectToAction("Index", "Academies", new { id = MinistereId });
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
