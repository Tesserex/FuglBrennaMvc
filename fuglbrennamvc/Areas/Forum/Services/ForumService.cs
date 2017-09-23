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
        private const int PAGE_LENGTH = 25;

        public ForumService(FuglBrennaEntities context)
        {
            this.context = context;
        }

        public object GetTopic(int topicId, int page)
        {
            var topic = this.context.ForumTopics.Find(topicId);
            var posts = topic.ForumPosts
                .OrderBy(p => p.CreatedOn)
                .Skip((page - 1) * PAGE_LENGTH)
                .Take(PAGE_LENGTH)
                .Select(p => new {
                    p.ForumPostId,
                    p.Content,
                    p.Member,
                    p.CreatedOn
                })
                .ToList()
                .Select(p => new ForumPostViewModel() {
                    Id = p.ForumPostId,
                    Content = p.Content,
                    MemberId = p.Member.MemberId,
                    MemberName = p.Member.DisplayName,
                    CreatedOn = p.CreatedOn
                })
                .ToList();

            return new ForumTopicPageViewModel() {
                TopicId = topicId,
                TopicTitle = topic.Title,
                Posts = posts
            };
        }

        public int ReplyToTopic(ReplyViewModel model)
        {
            var post = new ForumPost() {
                ForumTopicId = model.TopicId,
                Content = model.Content,
                CreatedMemberId = GetMemberId(),
                CreatedOn = DateTime.Now.ToUniversalTime()
            };

            this.context.ForumPosts.Add(post);
            this.context.SaveChanges();

            var postCount = this.context.ForumPosts
                .Where(p => p.ForumTopicId == model.TopicId)
                .Count();

            var topic = this.context.ForumTopics.Find(model.TopicId);
            topic.PostCount = postCount;
            this.context.SaveChanges();

            var lastPage = ((postCount - 1) / PAGE_LENGTH) + 1;
            return lastPage;
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
                    PostCount = x.ForumTopics.Sum(t => (int?)t.PostCount) ?? 0,
                    LastPost = x.ForumTopics
                        .SelectMany(t => t.ForumPosts)
                        .OrderByDescending(t => t.CreatedOn)
                        .Select(p => new { p.Member, p.CreatedOn, p.ForumTopicId, p.ForumTopic.Title })
                        .FirstOrDefault()
                })
                .ToList()
                .Select(x => new ForumSectionViewModel() {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedBy = x.Member.DisplayName,
                    TopicCount = x.TopicCount,
                    PostCount = x.PostCount,
                    LastPostAuthor = x.LastPost?.Member.DisplayName,
                    LastPostTime = x.LastPost?.CreatedOn,
                    LastPostTopic = x.LastPost?.Title,
                    LastPostTopicId = x.LastPost?.ForumTopicId
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