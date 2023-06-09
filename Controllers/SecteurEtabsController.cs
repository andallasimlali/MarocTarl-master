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
    public class SecteurEtabsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SecteurEtabs
        public ActionResult Index()
        {
            var secteurEtabs = db.SecteurEtabs.Include(s => s.Etab).Include(s => s.Secteur);
            return View(secteurEtabs.ToList());
        }

        // GET: SecteurEtabs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecteurEtab secteurEtab = db.SecteurEtabs.Find(id);
            if (secteurEtab == null)
            {
                return HttpNotFound();
            }
            return View(secteurEtab);
        }

        // GET: SecteurEtabs/Create
        public ActionResult Create()
        {
            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name");
            ViewBag.SecteurId = new SelectList(db.Secteurs, "Id", "Name");
            return View();
        }

        // POST: SecteurEtabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SecteurId,EtabId")] SecteurEtab secteurEtab)
        {
            if (ModelState.IsValid)
            {
                secteurEtab.Id = Guid.NewGuid();
                db.SecteurEtabs.Add(secteurEtab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name", secteurEtab.EtabId);
            ViewBag.SecteurId = new SelectList(db.Secteurs, "Id", "Name", secteurEtab.SecteurId);
            return View(secteurEtab);
        }

        // GET: SecteurEtabs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecteurEtab secteurEtab = db.SecteurEtabs.Find(id);
            if (secteurEtab == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name", secteurEtab.EtabId);
            ViewBag.SecteurId = new SelectList(db.Secteurs, "Id", "Name", secteurEtab.SecteurId);
            return View(secteurEtab);
        }

        // POST: SecteurEtabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SecteurId,EtabId")] SecteurEtab secteurEtab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secteurEtab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtabId = new SelectList(db.Etabs, "Id", "Name", secteurEtab.EtabId);
            ViewBag.SecteurId = new SelectList(db.Secteurs, "Id", "Name", secteurEtab.SecteurId);
            return View(secteurEtab);
        }

        // GET: SecteurEtabs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecteurEtab secteurEtab = db.SecteurEtabs.Find(id);
            if (secteurEtab == null)
            {
                return HttpNotFound();
            }
            return View(secteurEtab);
        }

        // POST: SecteurEtabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecteurEtab secteurEtab = db.SecteurEtabs.Find(id);
            db.SecteurEtabs.Remove(secteurEtab);
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
