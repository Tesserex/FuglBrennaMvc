using FuglBrennaMvc.Areas.Forum.ViewModels.Section;
using FuglBrennaMvc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Areas.Forum.Controllers
{
    public class SectionController : Controller
    {
        // GET: Section
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreatePost(CreateViewModel model)
        {
            using (var db = new FuglBrennaEntities())
            {
                var userId = User.Identity.GetUserId<int>();
                var memberLogin = db.MemberLogins.Find(userId);

                var section = new ForumSection() {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedMemberId = memberLogin.MemberId.Value
                };

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}