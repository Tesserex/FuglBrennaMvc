using System.Collections.Generic;

namespace FuglBrennaMvc.Areas.Forum.ViewModels.Topic
{
    public class ForumTopicPageViewModel
    {
        public ForumTopicPageViewModel()
        {
        }

        public int TopicId { get; set; }
        public string TopicTitle { get; set; }
        public List<ForumPostViewModel> Posts { get; set; }
    }
}