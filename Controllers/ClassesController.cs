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
    public class ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Classes
        public ActionResult Index(Guid id) // = EtabId
        {
            ViewBag.id = id;
            var classes = db.Classes.Where(x=>x.EtabId==id).Include(c => c.Etab);
            return View(classes.OrderBy(x=>x.Name).ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // GET: Classes/Create
        public ActionResult Create(Guid id) // = EtabId
        {
            Classe c = new Classe();
            c.EtabId = id;

            return View(c);
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EtabId,Niveau")] Classe classe)
        {

            var etab = db.Etabs.Where(x => x.Id == classe.EtabId).Include(x=>x.Direction.Academie.Ministere).FirstOrDefault();

            if (etab==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            classe.AnnéeScolaire = etab.Direction.Academie.Ministere.AnnéeSColaire;

            if (ModelState.IsValid)
            {
                classe.Id = Guid.NewGuid();
                db.Classes.Add(classe);
                db.SaveChanges();
                return RedirectToAction("Index" , new { id= classe.EtabId});
            }

            return View(classe);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }

            return View(classe);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EtabId,Niveau")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = classe.EtabId });
            }

            return View(classe);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Classe classe = db.Classes.Find(id);
            var EtabId = classe.EtabId;
            db.Classes.Remove(classe);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = EtabId });
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
