using System.Data.Entity.ModelConfiguration; 

namespace Repository
{
    public class Kiba_VideoMap : EntityTypeConfiguration<Kiba_Video>
    {
        public Kiba_VideoMap()
        {
            this.HasRequired(t => t.Kiba_Role).WithMany(t => t.Kiba_Video).WillCascadeOnDelete(false); //因为我设置了懒惰加载，所以这里设置成True也没用。
            this.Property(e => e.VideoName)
              .IsUnicode(false);
            this.Property(e => e.VideoUrl)
            .IsUnicode(false);
            this.Property(e => e.ModifyUserName)
                .IsUnicode(false); 
            this.Property(e => e.Remark)
                .IsUnicode(false);  
        }
    }
}
