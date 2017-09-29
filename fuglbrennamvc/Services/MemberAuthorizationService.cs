using FuglBrennaMvc.Areas.Forum.Models;
using FuglBrennaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Services
{
    public class MemberAuthorizationService
    {
        private readonly FuglBrennaEntities context;

        public MemberAuthorizationService(FuglBrennaEntities context)
        {
            this.context = context;
        }

        public bool ValidatePermissions(int userId, Permissions[] permissions)
        {
            if (permissions == null || !permissions.Any())
            {
                return true;
            }

            using (var db = new FuglBrennaEntities())
            {
                var memberPermissions = db.MemberRoles
                    .Where(m => m.MemberLoginId == userId)
                    .SelectMany(m => m.Role.RolePermissions)
                    .Select(p => p.Permission)
                    .Distinct()
                    .ToList();

                var hasPermission = permissions.Cast<int>().Intersect(memberPermissions).Any();

                return hasPermission;
            }
        }
    }
}