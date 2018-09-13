using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_HechoDeViolenciaMap : EntityTypeConfiguration<TC_HechoDeViolencia>
    {
        public TC_HechoDeViolenciaMap()
        {
            // Primary Key
            this.HasKey(t => t.idHechoDeViolencia);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_HechoDeViolencia");
            this.Property(t => t.idHechoDeViolencia).HasColumnName("idHechoDeViolencia");
            this.Property(t => t.armaDeFuego).HasColumnName("armaDeFuego");
            this.Property(t => t.armaBlanca).HasColumnName("armaBlanca");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");

            // Relationships
            this.HasRequired(t => t.TC_Incidente)
                .WithMany(t => t.TC_HechoDeViolencia)
                .HasForeignKey(d => d.idIncidente);

        }
    }
}
