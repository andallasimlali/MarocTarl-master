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
    public class StudentExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentExams
        public ActionResult Index()
        {
            var studentExams = db.StudentExams.Include(s => s.EtabFonctionnaire);
            return View(studentExams.ToList());
        }

        // GET: StudentExams/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentExam studentExam = db.StudentExams.Find(id);
            if (studentExam == null)
            {
                return HttpNotFound();
            }
            return View(studentExam);
        }

        // GET: StudentExams/Create
        public ActionResult Create()
        {
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id");
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "Title");
            ViewBag.GroupeClasseStudentId = new SelectList(db.GroupeClasseStudents, "Id", "Id");
            return View();
        }

        // POST: StudentExams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupeClasseStudentId,ExamId,DateAdd,EtabFonctionnaireId,TypeExam")] StudentExam studentExam)
        {
            if (ModelState.IsValid)
            {
                studentExam.Id = Guid.NewGuid();
                db.StudentExams.Add(studentExam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", studentExam.EtabFonctionnaireId);
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "Title", studentExam.ExamId);
            ViewBag.GroupeClasseStudentId = new SelectList(db.GroupeClasseStudents, "Id", "Id", studentExam.GroupeClasseStudentId);
            return View(studentExam);
        }

        // GET: StudentExams/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentExam studentExam = db.StudentExams.Find(id);
            if (studentExam == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", studentExam.EtabFonctionnaireId);
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "Title", studentExam.ExamId);
            ViewBag.GroupeClasseStudentId = new SelectList(db.GroupeClasseStudents, "Id", "Id", studentExam.GroupeClasseStudentId);
            return View(studentExam);
        }

        // POST: StudentExams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupeClasseStudentId,ExamId,DateAdd,EtabFonctionnaireId,TypeExam")] StudentExam studentExam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentExam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtabFonctionnaireId = new SelectList(db.EtabFonctionnaires, "Id", "Id", studentExam.EtabFonctionnaireId);
            ViewBag.ExamId = new SelectList(db.Exams, "Id", "Title", studentExam.ExamId);
            ViewBag.GroupeClasseStudentId = new SelectList(db.GroupeClasseStudents, "Id", "Id", studentExam.GroupeClasseStudentId);
            return View(studentExam);
        }

        // GET: StudentExams/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentExam studentExam = db.StudentExams.Find(id);
            if (studentExam == null)
            {
                return HttpNotFound();
            }
            return View(studentExam);
        }

        // POST: StudentExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StudentExam studentExam = db.StudentExams.Find(id);
            db.StudentExams.Remove(studentExam);
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
