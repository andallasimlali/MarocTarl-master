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
    public class EtabFonctionnairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EtabFonctionnaires
        public ActionResult Index()
        {
            var etabFonctionnaires = db.EtabFonctionnaires;
            return View(etabFonctionnaires.ToList());
        }

        // GET: EtabFonctionnaires/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtabFonctionnaire etabFonctionnaire = db.EtabFonctionnaires.Find(id);
            if (etabFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(etabFonctionnaire);
        }

        // GET: EtabFonctionnaires/Create
        public ActionResult Create()
        {
            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name");
            return View();
        }

        // POST: EtabFonctionnaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EtabId,UserId,AnnéeScolaire")] EtabFonctionnaire etabFonctionnaire)
        {
            if (ModelState.IsValid)
            {
                etabFonctionnaire.Id = Guid.NewGuid();
                db.EtabFonctionnaires.Add(etabFonctionnaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name", etabFonctionnaire.EtabId);
            return View(etabFonctionnaire);
        }

        // GET: EtabFonctionnaires/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtabFonctionnaire etabFonctionnaire = db.EtabFonctionnaires.Find(id);
            if (etabFonctionnaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name", etabFonctionnaire.EtabId);
            return View(etabFonctionnaire);
        }

        // POST: EtabFonctionnaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EtabId,UserId,AnnéeScolaire")] EtabFonctionnaire etabFonctionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etabFonctionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name", etabFonctionnaire.EtabId);
            return View(etabFonctionnaire);
        }

        // GET: EtabFonctionnaires/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtabFonctionnaire etabFonctionnaire = db.EtabFonctionnaires.Find(id);
            if (etabFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(etabFonctionnaire);
        }

        // POST: EtabFonctionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EtabFonctionnaire etabFonctionnaire = db.EtabFonctionnaires.Find(id);
            db.EtabFonctionnaires.Remove(etabFonctionnaire);
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
