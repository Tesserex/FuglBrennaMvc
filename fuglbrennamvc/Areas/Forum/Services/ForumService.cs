using FuglBrennaMvc.Areas.Forum.ViewModels;
using FuglBrennaMvc.Areas.Forum.ViewModels.Section;
using FuglBrennaMvc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FuglBrennaMvc.Areas.Forum.ViewModels.Topic;

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
                    Id = x.ForumSectionId,
                    Name = x.Name,
                    Description = x.Description,
                    Member = x.Member,
                    TopicCount = x.ForumTopics.Count,
                    PostCount = x.ForumTopics.Sum(t => (int?)t.PostCount) ?? 0
                })
                .ToList()
                .Select(x => new ForumSectionViewModel() {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedBy = x.Member.DisplayName,
                    TopicCount = x.TopicCount,
                    PostCount = x.PostCount
                })
                .ToList();
        }

        public int CreateTopic(CreateTopicViewModel model)
        {
            var memberId = GetMemberId();
            var now = DateTime.Now.ToUniversalTime();

            var topic = new ForumTopic() {
                ForumSectionId = model.SectionId,
                Title = model.Title,
                CreatedMemberId = memberId,
                CreatedOn = now,
                PostCount = 1
            };

            topic.ForumPosts.Add(new ForumPost() {
                Content = model.Content,
                CreatedMemberId = memberId,
                CreatedOn = now
            });

            this.context.ForumTopics.Add(topic);
            this.context.SaveChanges();

            return topic.ForumTopicId;
        }

        public ForumSectionViewModel GetSection(int id)
        {
            return this.context.ForumSections
                .Where(x => x.ForumSectionId == id)
                .Select(x => new {
                    Id = x.ForumSectionId,
                    Name = x.Name,
                    Description = x.Description,
                    Member = x.Member,
                    TopicCount = x.ForumTopics.Count,
                    PostCount = x.ForumTopics.Sum(t => (int?)t.PostCount) ?? 0
                })
                .ToList()
                .Select(x => new ForumSectionViewModel() {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedBy = x.Member.DisplayName,
                    TopicCount = x.TopicCount,
                    PostCount = x.PostCount
                })
                .SingleOrDefault();
        }

        public IEnumerable<ForumTopicViewModel> GetSectionTopics(int id)
        {
            return this.context.ForumTopics
                .Where(t => t.ForumSectionId == id)
                .Select(t => new {
                    t.ForumTopicId,
                    t.Title,
                    t.Member,
                    t.PostCount,
                    LastPost = t.ForumPosts
                        .OrderByDescending(p => p.CreatedOn)
                        .Select(p => new { p.CreatedOn, p.Member })
                        .FirstOrDefault()
                })
                .ToList()
                .Select(x => new ForumTopicViewModel() {
                    Id = x.ForumTopicId,
                    Title = x.Title,
                    CreatedBy = x.Member.DisplayName,
                    PostCount = x.PostCount,
                    LastPostMember = x.LastPost?.Member.DisplayName,
                    LastPostDate = x.LastPost?.CreatedOn
                })
                .ToList();
        }

        public void AddForumSection(CreateSectionViewModel model)
        {
            int memberId = GetMemberId();

            var section = new ForumSection() {
                Name = model.Name,
                Description = model.Description,
                CreatedMemberId = memberId
            };

            this.context.ForumSections.Add(section);

            this.context.SaveChanges();
        }

        private int GetMemberId()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId<int>();
            var memberId = this.context.MemberLogins.Find(userId).MemberId.Value;
            return memberId;
        }
    }
}