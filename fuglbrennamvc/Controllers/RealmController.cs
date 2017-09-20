using FuglBrennaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Controllers
{
    public class RealmController : Controller
    {
        private FuglBrennaEntities db = new FuglBrennaEntities();
        // GET: Realm
        public ActionResult Index()
        {
            var RealmsList = db.Realms.ToList();
            
            return View(RealmsList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // Now we can make the action for submitting a new member, only responds to POST
        [HttpPost]
        public ActionResult Add(Realm realm)
        {
            this.db.Realms.Add(realm);
            
            this.db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}