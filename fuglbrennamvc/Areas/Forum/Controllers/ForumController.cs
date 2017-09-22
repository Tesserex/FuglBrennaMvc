using FuglBrennaMvc.Areas.Forum.Services;
using FuglBrennaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuglBrennaMvc.Areas.Forum.Controllers
{
    public abstract class ForumController : Controller
    {
        protected ForumService ForumService { get; private set; }

        public ForumController()
        {
            this.ForumService = new ForumService(new FuglBrennaEntities());
        }
    }
}