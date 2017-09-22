using FuglBrennaMvc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FuglBrennaMvc.Areas.Forum.Helpers
{
    public class AuthorizeMemberAttribute : AuthorizeAttribute
    {
        public string Message { get; set; }

        public AuthorizeMemberAttribute()
        {
            this.Message = "Please complete your profile.";
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext))
            {
                return false;
            }

            var userId = httpContext.User.Identity.GetUserId<int>();

            // and check if he has completed his profile
            if (!this.HasMemberInfo(userId))
            {
                httpContext.Items["redirectToCompleteProfile"] = true;
                return false;
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Items.Contains("redirectToCompleteProfile"))
            {
                var routeValues = new RouteValueDictionary(new {
                    controller = "Manage",
                    action = "Index",
                });
                filterContext.Result = new RedirectToRouteResult(routeValues);

                filterContext.HttpContext.Response.Cookies.Add(new HttpCookie("FlashMessage", this.Message));
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

        private bool HasMemberInfo(int id)
        {
            using (var db = new FuglBrennaEntities())
            {
                var member = db.MemberLogins
                    .Where(m => m.MemberLoginId == id)
                    .Select(m => m.Member)
                    .SingleOrDefault();

                if (member == null) return false;

                if (!string.IsNullOrWhiteSpace(member.BattleName) ||
                    !string.IsNullOrWhiteSpace(member.FirstName))
                {
                    return true;
                }

                return false;
            }
        }
    }
}