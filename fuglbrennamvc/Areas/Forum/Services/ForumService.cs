using FuglBrennaMvc.Areas.Forum.ViewModels.Section;
using FuglBrennaMvc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Areas.Forum.Services
{
    public class ForumService
    {
        private readonly FuglBrennaEntities context;

        public ForumService(FuglBrennaEntities context)
        {
            this.context = context;
        }

        public IEnumerable<ForumSectionViewModel> GetSections()
        {
            return this.context.ForumSections
                .Select(x => new {
                    Name = x.Name,
                    Description = x.Description,
                    Member = x.Member,
                    TopicCount = x.ForumTopics.Count,
                    PostCount = x.ForumTopics.Sum(t => (int?)t.PostCount) ?? 0
                })
                .ToList()
                .Select(x => new ForumSectionViewModel() {
                    Name = x.Name,
                    Description = x.Description,
                    CreatedBy = x.Member.DisplayName,
                    TopicCount = x.TopicCount,
                    PostCount = x.PostCount
                })
                .ToList();
        }

        public void AddForumSection(CreateSectionViewModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId<int>();
            var memberLogin = this.context.MemberLogins.Find(userId);

            var section = new ForumSection() {
                Name = model.Name,
                Description = model.Description,
                CreatedMemberId = memberLogin.MemberId.Value
            };

            this.context.ForumSections.Add(section);

            this.context.SaveChanges();
        }
    }
}