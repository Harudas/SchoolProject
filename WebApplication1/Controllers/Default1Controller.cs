using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Default1Controller : Controller
    {
        public List<Person> GetData()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person()
            {
                Id = 1,
                Name = "阿萱",
                Phone = "09XXXXXXX1"
            });
            persons.Add(new Person()
            {
                Id = 2,
                Name = "杰鋒",
                Phone = "09XXXXXXX2"
            });
            persons.Add(new Person()
            {
                Id = 3,
                Name = "還敢蔡阿杰鋒",
                Phone = "09XXXXXXX3"
            });
            persons.Add(new Person()
            {
                Id = 4,
                Name = "君君",
                Phone = "09XXXXXXX4"
            });
            persons.Add(new Person()
            {
                Id = 5,
                Name = "年糕",
                Phone = "09XXXXXXX5"
            });
            persons.Add(new Person()
            {
                Id = 6,
                Name = "ㄚㄚ",
                Phone = "09XXXXXXX6"
            });
            persons.Add(new Person()
            {
                Id = 7,
                Name = "瓊蕙",
                Phone = "09XXXXXXX7"
            });
            persons.Add(new Person()
            {
                Id = 8,
                Name = "Haru",
                Phone = "09XXXXXXX8"
            });
            return persons;
        }

        // GET: Default1
        public ActionResult Index()
        {
            var models = GetData();
            return View(models);
        }

        // GET: Default1/Details/5
        public ActionResult Details(int id)
        {
            var models = GetData();
            var model = models.Where(m => m.Id == id).First();
            return View(model);
        }

        // GET: Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
