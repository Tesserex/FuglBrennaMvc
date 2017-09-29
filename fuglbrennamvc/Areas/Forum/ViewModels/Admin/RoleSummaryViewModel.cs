using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Areas.Forum.ViewModels.Admin
{
    public class RoleSummaryViewModel
    {
        public string Name { get; internal set; }
        public int Members { get; internal set; }
        public int Permissions { get; internal set; }
    }
}