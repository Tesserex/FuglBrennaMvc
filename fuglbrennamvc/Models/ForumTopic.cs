//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ForumTopic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ForumTopic()
        {
            this.ForumPosts = new HashSet<ForumPost>();
        }
    
        public int ForumTopicId { get; set; }
        public int ForumSectionId { get; set; }
        public string Title { get; set; }
        public int CreatedMemberId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int PostCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
        public virtual ForumSection ForumSection { get; set; }
        public virtual Member Member { get; set; }
    }
}