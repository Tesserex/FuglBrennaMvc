using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Areas.Forum.ViewModels
{
    public class ForumTopicListViewModel
    {
        public string SectionName { get; set; }

        public IEnumerable<ForumTopicViewModel> Topics { get; set; }
        public int SectionId { get; set; }
    }
}