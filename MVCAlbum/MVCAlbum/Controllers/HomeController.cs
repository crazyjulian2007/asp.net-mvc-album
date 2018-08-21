using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAlbum.Models;
using PagedList;

namespace MVCAlbum.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Home(int page = 1)
        {
            if (Session[CDictionary.LOGIN_USER]!=null)
            {
                tUser t = Session[CDictionary.LOGIN_USER] as tUser;
                ViewBag.User = "Welcome: " + t.fUserName + " [" + t.fMail + "]";
            }
            else
            {
                ViewBag.User = "Hello";
            }

            int pagesize = 3;
            int currentpage = pagesize < 1 ? 1 : page;
            dbAlbumDemoEntities db = new dbAlbumDemoEntities();
            var all = from t in db.tAlbum
                      orderby t.fId ascending
                      select t;
            var pagelist = all.ToPagedList(currentpage, pagesize);

            return View(pagelist);
        }
    }
}