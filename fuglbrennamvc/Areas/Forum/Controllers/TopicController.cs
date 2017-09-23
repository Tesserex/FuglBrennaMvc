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
        public ActionResult Index(int? id, int page = 1)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var topic = this.ForumService.GetTopic(id.Value, page);

            return View(topic);
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

        [HttpPost]
        [AuthorizeMember]
        public ActionResult Reply(ReplyViewModel model)
        {
            var lastPage = this.ForumService.ReplyToTopic(model);
            return RedirectToAction("Index", new { id = model.TopicId, page = lastPage });
        }
    }
}