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
    public class MinisteresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly MinistereService ministereService = new MinistereService();

        public AnnéeSColaire GetCurrentAnnéeScolaire(Guid id)
        {
            return ministereService.GetCurrentAnnéeScolaire(id);
        }

        // GET: Ministeres
        public ActionResult Index()
        {
            return View(db.Ministeres.ToList());
        }

        // GET: Ministeres/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministere ministere = db.Ministeres.Find(id);
            if (ministere == null)
            {
                return HttpNotFound();
            }
            return View(ministere);
        }

        // GET: Ministeres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ministeres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AnnéeSColaire")] Ministere ministere)
        {
            if (ModelState.IsValid)
            {
                ministere.Id = Guid.NewGuid();
                db.Ministeres.Add(ministere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ministere);
        }

        // GET: Ministeres/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministere ministere = db.Ministeres.Find(id);
            if (ministere == null)
            {
                return HttpNotFound();
            }
            return View(ministere);
        }

        // POST: Ministeres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AnnéeSColaire")] Ministere ministere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ministere);
        }

        // GET: Ministeres/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministere ministere = db.Ministeres.Find(id);
            if (ministere == null)
            {
                return HttpNotFound();
            }
            return View(ministere);
        }

        // POST: Ministeres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Ministere ministere = db.Ministeres.Find(id);
            db.Ministeres.Remove(ministere);
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
