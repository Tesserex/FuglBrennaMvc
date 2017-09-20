using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FuglBrennaMvc.Models;

namespace FuglBrennaMvc.Controllers
{
    public class SubRealmsController : Controller
    {
        private FuglBrennaEntities db = new FuglBrennaEntities();

        // GET: SubRealms
        public ActionResult Index()
        {
            var subRealms = db.SubRealms.Include(s => s.Realm);
            return View(subRealms.ToList());
        }

        // GET: SubRealms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubRealm subRealm = db.SubRealms.Find(id);
            if (subRealm == null)
            {
                return HttpNotFound();
            }
            return View(subRealm);
        }

        // GET: SubRealms/Create
        public ActionResult Create()
        {
            ViewBag.RealmId = new SelectList(db.Realms, "RealmId", "RealmName");
            return View();
        }

        // POST: SubRealms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubRealm subRealm)
        {
            if (ModelState.IsValid)
            {
                db.SubRealms.Add(subRealm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RealmId = new SelectList(db.Realms, "RealmId", "RealmName", subRealm.RealmId);
            return View(subRealm);
        }

        // GET: SubRealms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubRealm subRealm = db.SubRealms.Find(id);
            if (subRealm == null)
            {
                return HttpNotFound();
            }
            ViewBag.RealmId = new SelectList(db.Realms, "RealmId", "RealmName", subRealm.RealmId);
            return View(subRealm);
        }

        // POST: SubRealms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubRealmId,SubRealmName,SubRealmState,SubRealmCity,SubRealmAddress,Location,PracticeDay,PracticeTime,RealmId")] SubRealm subRealm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subRealm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RealmId = new SelectList(db.Realms, "RealmId", "RealmName", subRealm.RealmId);
            return View(subRealm);
        }

        // GET: SubRealms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubRealm subRealm = db.SubRealms.Find(id);
            if (subRealm == null)
            {
                return HttpNotFound();
            }
            return View(subRealm);
        }

        // POST: SubRealms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubRealm subRealm = db.SubRealms.Find(id);
            db.SubRealms.Remove(subRealm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
