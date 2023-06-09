using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarocTarl.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace MarocTarl.Controllers
{
    public class MinistereFonctionnairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly MinistereService ministereService = new MinistereService();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AnnéeSColaire GetCurrentAnnéeScolaire(Guid id)
        {
            return ministereService.GetCurrentAnnéeScolaire(id);
        }
        // GET: MinistereFonctionnaires
        public ActionResult Index(Guid id) // MinistereId
        {
           /// ViewBag.AnnéeScolaire = put it here;
            ViewBag.id = id;
            var ministereFonctionnaires = db.MinistereFonctionnaires.Where(x => x.MinistereId == id).Include(m => m.Ministere);
            return View(ministereFonctionnaires.ToList());
        }

        // GET: MinistereFonctionnaires/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistereFonctionnaire ministereFonctionnaire = db.MinistereFonctionnaires.Find(id);
            if (ministereFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(ministereFonctionnaire);
        }

        [HttpGet]
        public ActionResult AddFonc(Guid id) // MinistereId
        {
            MinistereFonctionnaireVM mf = new MinistereFonctionnaireVM();
            mf.MinistereId = id;
            return View(mf);
        }


        [HttpPost]
        public async Task<ActionResult> AddFonc(MinistereFonctionnaireVM mfVM) // MinistereId
        {
            Random r = new Random();
            ApplicationUser NewUser = new ApplicationUser();
            NewUser.NomAr = mfVM.NomAr;
            NewUser.NomFr = mfVM.NomFr;
            NewUser.PrenomAr = mfVM.PrenomAr;
            NewUser.PrenomFr = mfVM.PrenomFr;
            NewUser.TEL = mfVM.TEL;
            NewUser.CIN = mfVM.CIN;
            NewUser.Gender = mfVM.Gender;


            NewUser.Email = mfVM.CIN + "@gmail.com";
            NewUser.UserName = mfVM.CIN;
            NewUser.PW =r.Next(111111,999999);




            if (ModelState.IsValid)
            {
               // var user = new ApplicationUser { UserName = NewUser.CIN, Email = NewUser.Email };
                var result = await UserManager.CreateAsync(NewUser, NewUser.PW.ToString());
                if (result.Succeeded)
                {

                    MinistereFonctionnaire mf = new MinistereFonctionnaire();
                    mf.MinistereId = mfVM.MinistereId;
                    mf.AnnéeSColaire = GetCurrentAnnéeScolaire(mfVM.MinistereId);
                    mf.UserId = NewUser.Id;

                    db.MinistereFonctionnaires.Add(mf);
                    db.SaveChanges();

                    return RedirectToAction("index", "MinistereFonctionnaires", new { id = mfVM.MinistereId });
                }

            }




            return RedirectToAction("index", "MinistereFonctionnaires", new { id = mfVM.MinistereId});
        }

        // GET: MinistereFonctionnaires/Create
        public ActionResult Create(Guid id) // MinistereId
        {
            MinistereFonctionnaire mf = new MinistereFonctionnaire();
            mf.MinistereId = id;
            return View(mf);
        }

        // POST: MinistereFonctionnaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MinistereId,UserId")] MinistereFonctionnaire ministereFonctionnaire)
        {

            ministereFonctionnaire.AnnéeSColaire = GetCurrentAnnéeScolaire(ministereFonctionnaire.MinistereId);
            if (ModelState.IsValid)
            {
                ministereFonctionnaire.Id = Guid.NewGuid();
                db.MinistereFonctionnaires.Add(ministereFonctionnaire);
                db.SaveChanges();
                return RedirectToAction("Index" , new { id= ministereFonctionnaire.MinistereId});
            }

            return View(ministereFonctionnaire);
        }

        // GET: MinistereFonctionnaires/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistereFonctionnaire ministereFonctionnaire = db.MinistereFonctionnaires.Find(id);
            if (ministereFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(ministereFonctionnaire);
        }

        // POST: MinistereFonctionnaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MinistereId,UserId")] MinistereFonctionnaire ministereFonctionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministereFonctionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = ministereFonctionnaire.MinistereId });
            }

            return View(ministereFonctionnaire);
        }

        // GET: MinistereFonctionnaires/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistereFonctionnaire ministereFonctionnaire = db.MinistereFonctionnaires.Find(id);
            if (ministereFonctionnaire == null)
            {
                return HttpNotFound();
            }
            return View(ministereFonctionnaire);
        }

        // POST: MinistereFonctionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MinistereFonctionnaire ministereFonctionnaire = db.MinistereFonctionnaires.Find(id);
            var MinistereId = ministereFonctionnaire.MinistereId;
            db.MinistereFonctionnaires.Remove(ministereFonctionnaire);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = MinistereId });
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
