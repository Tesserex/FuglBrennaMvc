using System;

namespace FuglBrennaMvc.Areas.Forum.ViewModels.Topic
{
    public class ForumPostViewModel
    {
        public ForumPostViewModel()
        {
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int MemberPostCount { get;  set; }
        public DateTime MemberJoinedOn { get; set; }
    }
}