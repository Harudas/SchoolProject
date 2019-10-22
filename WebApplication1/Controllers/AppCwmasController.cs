using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AppCwmasController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        public ActionResult FirstPart(string Fid) {
            var model = db.Cwma.FirstOrDefault(m => m.Fid == Fid);
            model.Status = 2;
            db.SaveChanges();
            return Content("FirstPart SUCCESS");
        }

        public ActionResult Fail(string Fid)
        {
            var model = db.Cwma.FirstOrDefault(m => m.Fid == Fid);
            model.Status = 1;
            db.SaveChanges();
            return Content("Fail SUCCESS");
        }

        public ActionResult Success(string Fid)
        {
            var model = db.Cwma.FirstOrDefault(m => m.Fid == Fid);
            model.Status = 3;
            db.SaveChanges();
            return Content("Success SUCCESS");
        }

        // GET: AppCwmas
        public ActionResult Index()
        {
            return View(db.Cwma.ToList());
        }

        // GET: AppCwmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cwma cwma = db.Cwma.Find(id);
            if (cwma == null)
            {
                return HttpNotFound();
            }
            return View(cwma);
        }

        // GET: AppCwmas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppCwmas/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Department,Applicant,MyDate,StartDay,EndDay,Mytime1,Mytime2,Purpose,ApplicantMatter,AssistanceMatter,Description,Fid,Status")] Cwma cwma)
        {
            if (ModelState.IsValid)
            {
                db.Cwma.Add(cwma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cwma);
        }

        // GET: AppCwmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cwma cwma = db.Cwma.Find(id);
            if (cwma == null)
            {
                return HttpNotFound();
            }
            return View(cwma);
        }

        // POST: AppCwmas/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Department,Applicant,MyDate,StartDay,EndDay,Mytime1,Mytime2,Purpose,ApplicantMatter,AssistanceMatter,Description,Fid,Status")] Cwma cwma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cwma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cwma);
        }

        // GET: AppCwmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cwma cwma = db.Cwma.Find(id);
            if (cwma == null)
            {
                return HttpNotFound();
            }
            return View(cwma);
        }

        // POST: AppCwmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cwma cwma = db.Cwma.Find(id);
            db.Cwma.Remove(cwma);
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
