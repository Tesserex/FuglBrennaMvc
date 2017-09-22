using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Areas.Forum.ViewModels.Topic
{
    public class CreateTopicViewModel
    {
        public int SectionId { get; set; }
        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}