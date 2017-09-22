using FuglBrennaMvc.Areas.Forum.ViewModels;
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

        public ActionResult Section(int id)
        {
            var section = this.ForumService.GetSection(id);
            var topics = this.ForumService.GetSectionTopics(id);

            var vm = new ForumTopicListViewModel() {
                SectionId = id,
                SectionName = section.Name,
                Topics = topics
            };

            return View("Section", vm);
        }
    }
}