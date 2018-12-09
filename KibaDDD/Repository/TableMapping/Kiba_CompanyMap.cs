using System.Data.Entity.ModelConfiguration; 

namespace Repository
{
    public class Kiba_CompanyMap : EntityTypeConfiguration<Kiba_Company>
    {
        public Kiba_CompanyMap()
        { 
            this.Property(e => e.CompanyName)
              .IsUnicode(false);
            this.Property(e => e.WebSite)
                .IsUnicode(false);
            this.Property(e => e.Address)
                .IsUnicode(false); 
            this.Property(e => e.Remark)
                .IsUnicode(false);  
        }
    }
}
