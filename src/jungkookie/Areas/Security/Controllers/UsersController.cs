using jungkookie.Areas.Security.Models;
using MyMvc.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jungkookie.Areas.Security.Controllers
{
    public class UsersController : Controller
    {

        private IList<Userview> users
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"] = new List<Userview>()
                    {
                        new Userview
                            {
                                Id = Guid.NewGuid(),
                                FirstName = "Ishaq",
                                LastName = "Hassan",
                                Age = 20,
                                Gender = "Male"
                            },

                        new Userview
                       {
                           Id = Guid.NewGuid(),
                           FirstName = "Szhack",
                           LastName = "Hassan",
                           Age = 20,
                            Gender = "Male"
                       }
                    };

                }
                return Session["data"] as List<Userview>;
            }
        }

        // GET: Security/Users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {

                var users = (from user in db.Users
                             select new Userview
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 Gender = user.Gender


                             }).ToList();
                return View(users);
            }
        }
        // GET: Security/Users/Details/5
        public ActionResult Details(Guid id)
        {
            using (var db = new DatabaseContext())
            {
                var users = db.Users.FirstOrDefault(u => u.Id == id);
                Userview user = new Userview
                {
                    Id = users.Id,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Age = users.Age,
                    Gender = users.Gender
               
                };
                
                
                return View(user);
            }

        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Genders = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },
                new SelectListItem
                { 
                    Value = "Female",
                    Text = "Female"
                }
            };
            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(Userview view)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                    db.Users.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        FirstName = view.FirstName,
                        LastName = view.LastName,
                        Age = view.Age,
                        Gender = view.Gender
                    });
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.Genders = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },
                new SelectListItem
                { 
                    Value = "Female",
                    Text = "Female"
                }
            };
           
            return View();
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Userview view)
        {
            try
            {
                var u = users.FirstOrDefault(user => user.Id == id);
                u.FirstName = view.FirstName;
                u.LastName = view.LastName;
                u.Age = view.Age;
                u.Gender = view.Gender;
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            var u = users.FirstOrDefault(user => user.Id == id);
            return View(u);
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var u = users.FirstOrDefault(user => user.Id == id);
                users.Remove(u);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
