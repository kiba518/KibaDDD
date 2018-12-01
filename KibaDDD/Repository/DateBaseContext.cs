using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodeFirstStoredProcs;

namespace Repository
{
    public partial class DateBaseContext : DbContext
    {
       
        public DateBaseContext()
            : base("name=DateBaseContext")
        {
            this.Configuration.ValidateOnSaveEnabled = true;//保存时验证
            this.Configuration.AutoDetectChangesEnabled = true;//跟踪变化
            this.Configuration.LazyLoadingEnabled = true;//懒惰加载
            this.Configuration.ProxyCreationEnabled = true;//代理创建数据库
        }

        #region Table List
        public virtual DbSet<Kiba_User> Kiba_User { get; set; }
   
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Configurations.Add(new Kiba_UserMap()); 
        }
    }
}
