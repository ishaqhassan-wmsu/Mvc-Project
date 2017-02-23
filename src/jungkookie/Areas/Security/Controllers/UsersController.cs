using jungkookie.Areas.Security.Models;
using MyMvc.Dal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                                 Gender = user.Gender,
                                 EmploymentDate = user.EmploymentDate

                             }).ToList();
                return View(users);
            }
        }
        // GET: Security/Users/Details/5
        public ActionResult Details(int id)
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
                                 Gender = user.Gender,
                                 EmploymentDate = user.EmploymentDate

                             }).FirstOrDefault();
                return View(users);
            }

            //try
            //{
            //    using (var db = new DatabaseContext())
            //    {
            //        string sql = @"exec GetUserById @id";
            //        db.Database.SqlQuery(sql,
            //            new SqlParameter[] {
            //            new SqlParameter("@id",id)
            //        });

            //        return View(users);
            //    }
            //}
            //catch
            //{
            //    return View();
            //}

            

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
                 //using (var db = new DatabaseContext())
                //{
                //    string sql = @"exec uspCreateUser @fname, @lname, @age, @gender, @empDate, @school, @yrAttended";
                //    db.Database.ExecuteSqlCommand(sql,
                //        new SqlParameter[] {
                //        new SqlParameter("@fname",view.FirstName),
                //        new SqlParameter("@lname",view.LastName),
                //        new SqlParameter("@age",view.Age),
                //        new SqlParameter("@gender",view.Gender),
                //        new SqlParameter("@empDate",DateTime.UtcNow),
                //        new SqlParameter("@school","WMSU"),
                //        new SqlParameter("@yrAttended","2002")
                //    });
                //    return RedirectToAction("Index");
                //}

                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                    var newUser = new User
                    {
                        FirstName = view.FirstName,
                        LastName = view.LastName,
                        Age = view.Age,
                        Gender = view.Gender,
                        EmploymentDate = view.EmploymentDate
                      
                    };
                    newUser.Educations.Add(new Education
                    {
                        School = "Static School",
                        YearAttended = "2010"
                    });
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            
            
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(int id)
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
                                 Gender = user.Gender,
                                 EmploymentDate = user.EmploymentDate


                             }).FirstOrDefault();
                return View(users);
            }
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Userview view)
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
                    users.EmploymentDate = view.EmploymentDate;
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
        public ActionResult Delete(int id)
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
                                 Gender = user.Gender,
                                 EmploymentDate = user.EmploymentDate


                             }).FirstOrDefault();
                return View(users);
            }
           
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
