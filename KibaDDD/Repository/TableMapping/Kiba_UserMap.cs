using System.Data.Entity.ModelConfiguration; 

namespace Repository
{
    public class Kiba_UserMap : EntityTypeConfiguration<Kiba_User>
    {
        public Kiba_UserMap()
        { 
            this.Property(e => e.UserName)
              .IsUnicode(false);
            this.Property(e => e.UserNickName)
                .IsUnicode(false);
            this.Property(e => e.Password)
                .IsUnicode(false); 
            this.Property(e => e.Remark)
                .IsUnicode(false);  
        }
    }
}
