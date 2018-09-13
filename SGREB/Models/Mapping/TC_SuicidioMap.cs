using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_SuicidioMap : EntityTypeConfiguration<TC_Suicidio>
    {
        public TC_SuicidioMap()
        {
            // Primary Key
            this.HasKey(t => t.idSuicidio);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_Suicidio");
            this.Property(t => t.idSuicidio).HasColumnName("idSuicidio");
            this.Property(t => t.Causa).HasColumnName("Causa");
            this.Property(t => t.incidente).HasColumnName("incidente");

            // Relationships
            this.HasOptional(t => t.TC_Incidente)
                .WithMany(t => t.TC_Suicidio)
                .HasForeignKey(d => d.incidente);
            this.HasOptional(t => t.TV_CausaSuicidio)
                .WithMany(t => t.TC_Suicidio)
                .HasForeignKey(d => d.Causa);

        }
    }
}
