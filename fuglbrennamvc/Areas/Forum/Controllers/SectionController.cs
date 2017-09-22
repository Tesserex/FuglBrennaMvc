using FuglBrennaMvc.Areas.Forum.Helpers;
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
    public class SectionController : ForumController
    {
        // GET: Section
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [AuthorizeMember]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        [AuthorizeMember]
        public ActionResult CreatePost(CreateSectionViewModel model)
        {
            this.ForumService.AddForumSection(model);

            return RedirectToAction("Index", "Home");
        }
    }
}