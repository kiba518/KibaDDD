
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
namespace Repository
{ 
    public partial class Kiba_User
    {
        public virtual Kiba_Company Kiba_Company { get; set; }
        public virtual ICollection<Kiba_Role> Kiba_Role { get; set; }
        [Key]
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }  
        [StringLength(100)]
        public string Password { get; set; } 
        public int? Age { get; set; } 
        public int? Sex { get; set; } 
        [StringLength(500)]
        public string Remark { get; set; }
       
    }
}
