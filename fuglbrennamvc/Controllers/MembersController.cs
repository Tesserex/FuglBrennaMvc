using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FuglBrennaMvc.Models;

namespace FuglBrennaMvc.Controllers {
    // This web design pattern is called MVC, which stands for Model, View, Controller. It separates
    // each of those three things so you don't have things like database code in your html. The controller
    // does the communication between the model (data) and view (html and such). Each controller class
    // is generally responsible for a single "page" or a single area of the site. Actions are special methods
    // (noted by having a return type of ActionResult) that represent single page loads. Each request to the site
    // calls a single action. This controller would handle everything about members, with separate actions like adding,
    // viewing details, editing, etc. Separate controllers would be used for other areas like shire management
    // or attendance. If you see a URL of the pattern website.com/area/thing, that means area is the controller and
    // thing is the action. That URL pattern is used here too.

    public class MembersController : Controller {
        // In more complicated systems you wouldn't just create a new database object here, but
        // it's totally fine for this sort of project.
        private FuglBrennaEntities db = new FuglBrennaEntities();

        // GET: Member
        public ActionResult Index() {
            // Getting a list of all members, this is easy. The AsQueryable just makes it
            // so that the Where clause below can be assigned to the same variable.
            var members = this.db.Members.AsQueryable();

            // An important note is that the database hasn't been queried yet. The members object
            // will let us add more parts onto it like where clauses before sending it to the db.

            // For example we could get everyone in a shire named Uppsala
            members = members.Where(m => m.SubRealm.SubRealmName == "Uppsala");

            // This line will hit the database for the results. Other methods like ToDictionary would also do that.
            var memberList = members.ToList();

            // The View method will by default look for a cshtml file with the same name as this action, in a folder
            // with the same name as the controller. You can pass in a custom view name if you want.
            // We will just pass in the memberList as a model.
            return View(memberList);

            // Now go look in Views/Members/Index.cshtml
        }

        // This attribute means that this method will only be called if it's a GET request
        [HttpGet]
        public ActionResult Add() {
            // we only need to get the list of shires for our dropdown box
            var shires = this.db.SubRealms.ToList();

            // another important note - usually we wouldn't just take database objects and send them
            // directly to the view. We almost always have to transform the data, combine tables, etc,
            // and we would put the results into a separate class called a ViewModel. That would be what
            // gets passed to the view. Notice there is a file that came with the project called AccountViewModels.

            return View(shires);
        }

        // Now we can make the action for submitting a new member, only responds to POST
        [HttpPost]
        public ActionResult Add(AddMemberModel member) {
            // ok, so I created a class called AddMemberModel. It's sort of like a viewmodel, but
            // used to get the data from the page. The app will automatically bind all the html
            // input fields to properties of this class, provided they have the same name.
            // (There might be a way to customize that but it's irrelevant.)

            // Also, yes the AddMemberModel has all the same properties as the Member class in the
            // database, but this just shows good practice (also that won't always be true, the db
            // could have tons of extra stuff we don't want.)

            this.db.Members.Add(new Member() {
                SubRealmId = member.SubRealmId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                BattleName = member.BattleName
            });

            // this SaveChanges call is needed to update the db after doing any adds or updates.
            // You don't have to call it after every change, just once at the end of your code is fine.
            this.db.SaveChanges();

            // instead of returning a view, we will redirect back to the index.
            return RedirectToAction("Index");
        }

        public ActionResult AttendanceRecords()
        {
            var bestShire = db.SubRealms
                .Select(x => x.Events.Where(e => e.EventType.Type == "Practice").OrderByDescending(e => e.EventDate).FirstOrDefault())
                .OrderByDescending(e => e != null ? e.Attendances.Count : 0)
                .First().SubRealm.SubRealmName;

            return View();
        }
    }
}