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
    public class AppWebpconsController : Controller
    {
        public ActionResult FirstPart(string Fid)
        {
            var model = db.Cwma.FirstOrDefault(m => m.Fid == Fid);
            model.Status = 1;
            db.SaveChanges();
            return Content("FirstPart SUCCESS");
        }

        public ActionResult Fail(string Fid)
        {
            var model = db.Cwma.FirstOrDefault(m => m.Fid == Fid);
            model.Status = 2;
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

        private DatabaseEntities db = new DatabaseEntities();

        // GET: Webpcons
        public ActionResult Index()
        {
            return View(db.Webpcon.ToList());
        }

        // GET: Webpcons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webpcon webpcon = db.Webpcon.Find(id);
            if (webpcon == null)
            {
                return HttpNotFound();
            }
            return View(webpcon);
        }

        // GET: Webpcons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Webpcons/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MyDate,Number,Side,System,Module,Project,FProject,AddFunction,elsetext,Description,Fid,Department,Applicant,Status")] Webpcon webpcon)
        {
            if (ModelState.IsValid)
            {
                db.Webpcon.Add(webpcon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webpcon);
        }

        // GET: Webpcons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webpcon webpcon = db.Webpcon.Find(id);
            if (webpcon == null)
            {
                return HttpNotFound();
            }
            return View(webpcon);
        }

        // POST: Webpcons/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MyDate,Number,Side,System,Module,Project,FProject,AddFunction,elsetext,Description,Fid,Department,Applicant,Status")] Webpcon webpcon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webpcon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webpcon);
        }

        // GET: Webpcons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webpcon webpcon = db.Webpcon.Find(id);
            if (webpcon == null)
            {
                return HttpNotFound();
            }
            return View(webpcon);
        }

        // POST: Webpcons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Webpcon webpcon = db.Webpcon.Find(id);
            db.Webpcon.Remove(webpcon);
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
