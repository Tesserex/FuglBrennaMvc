using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Areas.Forum.ViewModels.Section
{
    public class ForumSectionViewModel
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public string CreatedBy { get; internal set; }
        public int TopicCount { get; internal set; }
        public int PostCount { get; internal set; }
        public int Id { get; internal set; }
        public string LastPostAuthor { get; internal set; }
        public DateTime? LastPostTime { get; internal set; }
        public string LastPostTopic { get; internal set; }
        public int? LastPostTopicId { get; internal set; }
    }
}