using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Areas.Forum.ViewModels.Admin
{
    public class DashboardViewModel
    {
        public List<RoleSummaryViewModel> Roles { get; internal set; }
    }
}