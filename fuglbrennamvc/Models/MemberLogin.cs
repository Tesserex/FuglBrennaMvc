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
    
    public partial class MemberLogin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberLogin()
        {
            this.MemberRoles = new HashSet<MemberRole>();
        }
    
        public int MemberLoginId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public System.DateTime JoinedOn { get; set; }
    
        public virtual Member Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
