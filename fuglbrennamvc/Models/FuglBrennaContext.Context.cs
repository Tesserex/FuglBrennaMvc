﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FuglBrennaMvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FuglBrennaEntities : DbContext
    {
        public FuglBrennaEntities()
            : base("name=FuglBrennaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<MemberLogin> MemberLogins { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Realm> Realms { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SubRealm> SubRealms { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<ForumPost> ForumPosts { get; set; }
        public virtual DbSet<ForumSection> ForumSections { get; set; }
        public virtual DbSet<ForumTopic> ForumTopics { get; set; }
    }
}
