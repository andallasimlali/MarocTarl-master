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
    public class ReponsesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reponses
        public ActionResult Index()
        {
            var reponses = db.Reponses.Include(r => r.Choice);
            return View(reponses.ToList());
        }

        // GET: Reponses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // GET: Reponses/Create
        public ActionResult Create()
        {
            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Text");
            ViewBag.StudentExamId = new SelectList(db.StudentExams, "Id", "Id");
            return View();
        }

        // POST: Reponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsCorrect,ChoiceId,DateAdd,StudentExamId")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                reponse.Id = Guid.NewGuid();
                db.Reponses.Add(reponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Text", reponse.ChoiceId);
            ViewBag.StudentExamId = new SelectList(db.StudentExams, "Id", "Id", reponse.StudentExamId);
            return View(reponse);
        }

        // GET: Reponses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Text", reponse.ChoiceId);
            ViewBag.StudentExamId = new SelectList(db.StudentExams, "Id", "Id", reponse.StudentExamId);
            return View(reponse);
        }

        // POST: Reponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsCorrect,ChoiceId,DateAdd,StudentExamId")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Text", reponse.ChoiceId);
            ViewBag.StudentExamId = new SelectList(db.StudentExams, "Id", "Id", reponse.StudentExamId);
            return View(reponse);
        }

        // GET: Reponses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // POST: Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Reponse reponse = db.Reponses.Find(id);
            db.Reponses.Remove(reponse);
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
