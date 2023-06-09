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
    public class ExcelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET action to display the import form


        // GET: Excels
        public ActionResult Index()
        {
            return View(db.Excels.ToList());
        }

        // GET: Excels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excel excel = db.Excels.Find(id);
            if (excel == null)
            {
                return HttpNotFound();
            }
            return View(excel);
        }

        // GET: Excels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Excels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Excel excel)
        {
            if (ModelState.IsValid)
            {
                excel.Id = Guid.NewGuid();
                db.Excels.Add(excel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excel);
        }

        // GET: Excels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excel excel = db.Excels.Find(id);
            if (excel == null)
            {
                return HttpNotFound();
            }
            return View(excel);
        }

        // POST: Excels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Excel excel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excel);
        }

        // GET: Excels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excel excel = db.Excels.Find(id);
            if (excel == null)
            {
                return HttpNotFound();
            }
            return View(excel);
        }

        // POST: Excels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Excel excel = db.Excels.Find(id);
            db.Excels.Remove(excel);
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
