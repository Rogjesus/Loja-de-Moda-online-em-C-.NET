using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using DigitalFashionPortal_MVC.Models;

namespace DigitalFashionPortal_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();

        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(TblUser tblUser)
        {
            using (DigitalFashionEntities db = new DigitalFashionEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblUsers.Add(tblUser);
                    db.SaveChanges();
                    //  ViewBag.message("Register Sucess");
                    ModelState.Clear();
                }
            }
            return View();
        }

        [HttpPost]

        public ActionResult Login(TblUser tblUser)
        {
            using (DigitalFashionEntities db = new DigitalFashionEntities())
            {
                if (ModelState.IsValid)
                {
                    var log = db.TblUsers.Where(a => a.userName.Equals(tblUser
                        .userName) && a.password.Equals(tblUser.password)).FirstOrDefault();
                    if (log != null)
                    {
                        return RedirectToAction("Contact");
                    }
                    db.SaveChanges();
                    // ViewBag.message("Login Sucess");
                    ModelState.Clear();
                }
            }
            return View();
        }
    }
}