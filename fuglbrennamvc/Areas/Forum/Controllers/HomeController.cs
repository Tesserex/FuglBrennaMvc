using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Areas.Forum.Controllers
{
    public class HomeController : ForumController
    {
        // GET: Home
        public ActionResult Index()
        {
            var sections = this.ForumService.GetSections();

            return View(sections);
        }
    }
}