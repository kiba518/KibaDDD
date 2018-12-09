using System.Data.Entity.ModelConfiguration; 

namespace Repository
{
    public class Kiba_UserMap : EntityTypeConfiguration<Kiba_User>
    {
        public Kiba_UserMap()
        {
            this.HasRequired(t => t.Kiba_Company).WithMany(t => t.Kiba_User).WillCascadeOnDelete(false); //因为我设置了懒惰加载，所以这里设置成True也没用。
            this.Property(e => e.UserName)
              .IsUnicode(false);
           
            this.Property(e => e.Password)
                .IsUnicode(false); 
            this.Property(e => e.Remark)
                .IsUnicode(false);  
        }
    }
}
