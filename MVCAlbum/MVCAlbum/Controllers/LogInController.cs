using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAlbum.Models;

namespace MVCAlbum.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string acNum,string pwd)
        {
            dbAlbumDemoEntities db = new dbAlbumDemoEntities();
            tUser u = db.tUser.FirstOrDefault(
                t => t.fAcountName.Equals(acNum) && t.fPassword.Equals(pwd));
            if (u != null)
            {
                Session[CDictionary.LOGIN_USER] = u;
                return View("../Upload/Upload");
            }
            else
            {
                ViewBag.WrongMessage = "Wrong Account Number or Wrong Password";
                return View();
            }
            
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(tUser user)
        {
            if (user == null)
            {
                return View("New");
            }
            else
            {
                dbAlbumDemoEntities db = new dbAlbumDemoEntities();
                db.tUser.Add(user);
                db.SaveChanges();
                return View("Login");
            }
        }

      

    }
}