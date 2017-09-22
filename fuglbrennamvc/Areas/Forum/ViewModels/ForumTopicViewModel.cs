using System;

namespace FuglBrennaMvc.Areas.Forum.ViewModels
{
    public class ForumTopicViewModel
    {
        public ForumTopicViewModel()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public int PostCount { get; set; }
        public string LastPostMember { get; set; }
        public DateTime? LastPostDate { get; set; }
    }
}