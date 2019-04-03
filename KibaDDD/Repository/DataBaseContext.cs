using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodeFirstStoredProcs;
using System.Data.Entity.Migrations;

namespace Repository
{
    public partial class DataBaseContext : DbContext
    {

        public DataBaseContext()
            : base("name=DateBaseContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Configuration>()); //设置自动更新数据库修改
            //Database.SetInitializer<DateBaseContext>(new DropCreateDatabaseIfModelChanges<DateBaseContext>());//设置数据库如果有变化，每次都重新创建数据库
            this.Configuration.ValidateOnSaveEnabled = true;//保存时验证
            this.Configuration.AutoDetectChangesEnabled = true;//跟踪变化
            this.Configuration.LazyLoadingEnabled = true;//懒惰加载
            this.Configuration.ProxyCreationEnabled = true;//代理创建数据库 
        }

        #region Table List
        public virtual DbSet<Kiba_Company> Kiba_Company { get; set; }
        public virtual DbSet<Kiba_User> Kiba_User { get; set; } 
        public virtual DbSet<Kiba_Role> Kiba_Role { get; set; }
        public virtual DbSet<Kiba_Video> Kiba_Video { get; set; }
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//表示用于将表名称设置为实体类型名称的复数版本的约定。
            modelBuilder.Configurations.Add(new Kiba_UserMap());
            modelBuilder.Configurations.Add(new Kiba_RoleMap());
            modelBuilder.Configurations.Add(new Kiba_CompanyMap());
            modelBuilder.Configurations.Add(new Kiba_VideoMap());
        }
    }
    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; 
        }
    }
   
}
