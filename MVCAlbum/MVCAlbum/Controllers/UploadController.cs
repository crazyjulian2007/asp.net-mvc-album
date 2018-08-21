using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAlbum.Models;

namespace MVCAlbum.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Upload()
        {
            tUser user = Session[CDictionary.LOGIN_USER] as tUser;
            if (user == null)
            {
                return View("../Login/Login");//Login
            }
            else
            {
                ViewBag.User = "Welcome:" + user.fUserName + "[" + user.fMail + "]";
                return View();//Upload
            }
        }

        [HttpPost]
        public ActionResult Upload(tAlbum t,HttpPostedFileBase photo)
        {
            if ((t == null)|(photo==null))
                Response.Redirect("Upload");
            
            dbAlbumDemoEntities db = new dbAlbumDemoEntities();
            string photoname = Guid.NewGuid().ToString() + ".jpg";
            t.fPath = "../Content/img/" + photoname;
            photo.SaveAs(Server.MapPath("../Content/img/" + photoname));

            db.tAlbum.Add(t);
            db.SaveChanges();

            return View("../Home/Index");
        }
    }
}