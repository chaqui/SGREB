using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_RastreoMap : EntityTypeConfiguration<TC_Rastreo>
    {
        public TC_RastreoMap()
        {
            // Primary Key
            this.HasKey(t => t.idRastreo);

            // Properties
            this.Property(t => t.idRastreo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TC_Rastreo");
            this.Property(t => t.idRastreo).HasColumnName("idRastreo");
            this.Property(t => t.Localizada).HasColumnName("Localizada");
            this.Property(t => t.incidente).HasColumnName("incidente");

            // Relationships
            this.HasOptional(t => t.TC_Incidente)
                .WithMany(t => t.TC_Rastreo)
                .HasForeignKey(d => d.incidente);

        }
    }
}
