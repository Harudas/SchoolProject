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
    public class LoginController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string account, string password)
        {

            var db = new DatabaseEntities();
            var model = db.User.Where(m => m.Account == account && m.Password == password).FirstOrDefault();
            if (model != null)
            {
                Session["Account"] = model.Account;
                Session["Did"] = model.Did;
                Response.Redirect("~/Login/FormSelect");
                return new EmptyResult();

            }
            else
            {
                ViewBag.Msg = "所輸入的帳號或密碼有誤!!!";
                return View();
            }

        }

        public ActionResult FormSelect()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormSelect(FormCollection collection)
        {
            string select = collection["select"];

            if (select == "cwma")
            {
                Response.Redirect("~/Cwma/Index");
                return new EmptyResult();
            }
            if (select == "webpcon")
            {
                Response.Redirect("~/Webpcon/Index");
                return new EmptyResult();
            }

            return View();
        }

    }
}
