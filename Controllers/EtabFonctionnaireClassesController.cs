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
    public class EtabFonctionnaireClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EtabFonctionnaireClasses
        public ActionResult Index()
        {
            var etabFonctionnaireClasses = db.EtabFonctionnaireClasses.Include(e => e.Classe).Include(e => e.EtabFonctionnaire);
            return View(etabFonctionnaireClasses.ToList());
        }

        // GET: EtabFonctionnaireClasses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtabFonctionnaireClasse etabFonctionnaireClasse = db.EtabFonctionnaireClasses.Find(id);
            if (etabFonctionnaireClasse == null)
            {
                return HttpNotFound();
            }
            return View(etabFonctionnaireClasse);
        }

        // GET: EtabFonctionnaireClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name");
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id");
            return View();
        }

        // POST: EtabFonctionnaireClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClasseId,EtabFonctionnaireId")] EtabFonctionnaireClasse etabFonctionnaireClasse)
        {
            if (ModelState.IsValid)
            {
                etabFonctionnaireClasse.Id = Guid.NewGuid();
                db.EtabFonctionnaireClasses.Add(etabFonctionnaireClasse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name", etabFonctionnaireClasse.ClasseId);
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", etabFonctionnaireClasse.EtabFonctionnaireId);
            return View(etabFonctionnaireClasse);
        }

        // GET: EtabFonctionnaireClasses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtabFonctionnaireClasse etabFonctionnaireClasse = db.EtabFonctionnaireClasses.Find(id);
            if (etabFonctionnaireClasse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name", etabFonctionnaireClasse.ClasseId);
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", etabFonctionnaireClasse.EtabFonctionnaireId);
            return View(etabFonctionnaireClasse);
        }

        // POST: EtabFonctionnaireClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClasseId,EtabFonctionnaireId")] EtabFonctionnaireClasse etabFonctionnaireClasse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etabFonctionnaireClasse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "Name", etabFonctionnaireClasse.ClasseId);
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", etabFonctionnaireClasse.EtabFonctionnaireId);
            return View(etabFonctionnaireClasse);
        }

        // GET: EtabFonctionnaireClasses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtabFonctionnaireClasse etabFonctionnaireClasse = db.EtabFonctionnaireClasses.Find(id);
            if (etabFonctionnaireClasse == null)
            {
                return HttpNotFound();
            }
            return View(etabFonctionnaireClasse);
        }

        // POST: EtabFonctionnaireClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EtabFonctionnaireClasse etabFonctionnaireClasse = db.EtabFonctionnaireClasses.Find(id);
            db.EtabFonctionnaireClasses.Remove(etabFonctionnaireClasse);
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
