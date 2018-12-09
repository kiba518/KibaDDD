
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
namespace Repository
{
    public partial class Kiba_Video
    {
        public virtual Kiba_Role Kiba_Role { get; set; } 
        [Key]
        public int VideoId { get; set; }
        public int RoleId { get; set; }
        [Required]
        [StringLength(100)]
        public string VideoName { get; set; } 
        [StringLength(500)]
        public string VideoUrl { get; set; } 
        public DateTime? ModifyDate { get; set; } 
        public int? ModifyUserId { get; set; } 
        [StringLength(50)]
        public string ModifyUserName { get; set; } 
        [StringLength(500)]
        public string Remark { get; set; }
    }
}
