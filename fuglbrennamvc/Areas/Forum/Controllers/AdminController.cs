using FuglBrennaMvc.Areas.Forum.Helpers;
using FuglBrennaMvc.Areas.Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Areas.Forum.Controllers
{
    [AuthorizeMember(Permissions = new[] { Permissions.ManageRoles })]
    public class AdminController : ForumController
    {
        // GET: Forum/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}