
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
namespace Repository
{
    public partial class Kiba_Role
    {
        public virtual ICollection<Kiba_User> Kiba_User { get; set; }
        public virtual ICollection<Kiba_Video> Kiba_Video { get; set; }
        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } 
        public int? ParentRoleId { get; set; }
        public int? IsActive { get; set; }
        public int? RoleType { get; set; } 
        public DateTime? ModifyDate { get; set; } 
        public int? ModifyUserId { get; set; } 
        [StringLength(50)]
        public string ModifyUserName { get; set; } 
        [StringLength(500)]
        public string Remark { get; set; }
    }
}
