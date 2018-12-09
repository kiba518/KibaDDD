
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
namespace Repository
{ 
    public partial class Kiba_Company
    {
        public virtual ICollection<Kiba_User> Kiba_User { get; set; }
        [Key]
        public int CompanyId { get; set; } 
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; } 
        [StringLength(500)]
        public string Address { get; set; } 
        [StringLength(500)]
        public string WebSite { get; set; }  
        [StringLength(500)]
        public string Remark { get; set; }
       
    }
}
