using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class WebpconController : Controller
    {
        // GET: Webpcon
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SentForm(Webpcon model)
        {

            var service = new workflow();
            string pid = service.Webpconwork(Session["Account"].ToString(), Session["Did"].ToString(), model);
            model.Department = Session["Did"].ToString();
            model.Applicant = Session["Account"].ToString();
            model.Fid = pid;
            var db = new DatabaseEntities();
            db.Webpcon.Add(model);
            db.SaveChanges();
            return Content(pid);

        }
    }
}