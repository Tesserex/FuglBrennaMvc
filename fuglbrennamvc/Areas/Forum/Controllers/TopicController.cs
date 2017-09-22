using FuglBrennaMvc.Areas.Forum.Helpers;
using FuglBrennaMvc.Areas.Forum.ViewModels.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Areas.Forum.Controllers
{
    public class TopicController : ForumController
    {
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        [AuthorizeMember]
        public ActionResult Create(int id)
        {
            var section = this.ForumService.GetSection(id);
            return View(section);
        }

        [HttpPost]
        [AuthorizeMember]
        [ActionName("Create")]
        public ActionResult CreatePost(CreateTopicViewModel model)
        {
            var topicId = this.ForumService.CreateTopic(model);

            return RedirectToAction("Index", new { id = topicId });
        }
    }
}