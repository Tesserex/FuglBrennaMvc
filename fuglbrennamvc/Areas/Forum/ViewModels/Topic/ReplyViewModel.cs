using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Areas.Forum.ViewModels.Topic
{
    public class ReplyViewModel
    {
        public int TopicId { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}