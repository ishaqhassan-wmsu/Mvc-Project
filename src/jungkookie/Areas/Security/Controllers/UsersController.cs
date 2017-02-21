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
            get;
            set;
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

                var users = (from user in db.Users
                             where user.Id == id
                             select new Userview
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 Gender = user.Gender


                             }).FirstOrDefault();
                return View(users);
            }

        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            
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
            using (var db = new DatabaseContext())
            {

                var users = (from user in db.Users
                             where user.Id == id
                             select new Userview
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 Gender = user.Gender


                             }).FirstOrDefault();
                return View(users);
            }
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Userview view)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                    var users = (from user in db.Users
                             where user.Id == id
                             select user).FirstOrDefault();

                    users.FirstName = view.FirstName;
                    users.LastName = view.LastName;
                    users.Age = view.Age;
                    users.Gender = view.Gender; 
                    db.SaveChanges();
                }
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
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             where user.Id == id
                             select new Userview
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 Gender = user.Gender


                             }).FirstOrDefault();
                return View(users);
            }
           
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             where user.Id == id
                             select user).FirstOrDefault();
                db.Users.Remove(users);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
