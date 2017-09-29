using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Areas.Forum.Models
{
    public enum Permissions
    {
        ManageRoles = 1,
        AssignRoles = 2,
        ManageSections = 3,
        CreateTopic = 4,
        StickyTopic = 5,
        LockTopic = 6,
        DeleteTopic = 7,
        ViewTopic = 8,
        PostReply = 9,
        EditOtherPosts = 10,
        DeleteOtherPosts = 11,
        VotePost = 12,
        ManagePoll = 13,
        ViewPoll = 14,
        VotePoll = 15,
        ManageBans = 16,
    }
}