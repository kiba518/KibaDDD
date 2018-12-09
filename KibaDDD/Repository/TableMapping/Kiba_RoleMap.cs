using System.Data.Entity.ModelConfiguration; 

namespace Repository
{
    public class Kiba_RoleMap : EntityTypeConfiguration<Kiba_Role>
    {
        public Kiba_RoleMap()
        {
            this.HasMany(p => p.Kiba_User)//从这个实体类型配置一个多关系 
                     .WithMany(e => e.Kiba_Role)//配置这个多对多关系的另一端,另一端通过导航属性能够被访问 
                     .Map(m =>
                     {
                         m.ToTable("Kiba_UserOfRole").//配置用于存储关系的外键字段和表  
                         MapLeftKey("RoleId").//引用的左表字段  
                         MapRightKey("UserId");//引用的右表字段  
                       ;//中间表  
                   });
           
            this.Property(e => e.RoleName)
              .IsUnicode(false);
            this.Property(e => e.ModifyUserName)
                .IsUnicode(false); 
            this.Property(e => e.Remark)
                .IsUnicode(false);  
        }
    }
}
