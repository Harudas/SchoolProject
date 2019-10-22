using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CwmaController : Controller
    {
        // GET: Cwma
        public ActionResult Index()
        {
            return View();

        }

        //送出表單
        public ActionResult SentForm(Cwma model)
        {

            var service = new workflow();
            string pid = service.test(Session["Account"].ToString(), Session["Did"].ToString() ,model);
            model.Department = Session["Did"].ToString();
            model.Applicant = Session["Account"].ToString();
            model.Fid = pid;
            var db = new DatabaseEntities();
            db.Cwma.Add(model);
            db.SaveChanges();
            return Content(pid);

        }

    }
}