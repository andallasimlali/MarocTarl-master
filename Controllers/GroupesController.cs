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
    public class GroupesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groupes
        public ActionResult Index()
        {
            var groupes = db.Groupes.Include(g => g.EtabFonctionnaire);
            return View(groupes.ToList());
        }

        // GET: Groupes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        // GET: Groupes/Create
        public ActionResult Create()
        {
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id");
            return View();
        }

        // POST: Groupes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EtabFonctionnaireId,DateAdd,Default")] Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                groupe.Id = Guid.NewGuid();
                db.Groupes.Add(groupe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", groupe.EtabFonctionnaireId);
            return View(groupe);
        }

        // GET: Groupes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", groupe.EtabFonctionnaireId);
            return View(groupe);
        }

        // POST: Groupes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EtabFonctionnaireId,DateAdd,Default")] Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", groupe.EtabFonctionnaireId);
            return View(groupe);
        }

        // GET: Groupes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        // POST: Groupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Groupe groupe = db.Groupes.Find(id);
            db.Groupes.Remove(groupe);
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
