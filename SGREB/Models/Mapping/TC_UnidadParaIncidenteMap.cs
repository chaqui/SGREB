using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_UnidadParaIncidenteMap : EntityTypeConfiguration<TC_UnidadParaIncidente>
    {
        public TC_UnidadParaIncidenteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdUnidad, t.Incidente });

            // Properties
            this.Property(t => t.IdUnidad)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Incidente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.piloto)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TC_UnidadParaIncidente");
            this.Property(t => t.IdUnidad).HasColumnName("IdUnidad");
            this.Property(t => t.Incidente).HasColumnName("Incidente");
            this.Property(t => t.piloto).HasColumnName("piloto");

            // Relationships
            this.HasOptional(t => t.TC_Bombero)
                .WithMany(t => t.TC_UnidadParaIncidente)
                .HasForeignKey(d => d.piloto);
            this.HasRequired(t => t.TC_Incidente)
                .WithMany(t => t.TC_UnidadParaIncidente)
                .HasForeignKey(d => d.Incidente);
            this.HasRequired(t => t.TC_Unidad)
                .WithMany(t => t.TC_UnidadParaIncidente)
                .HasForeignKey(d => d.IdUnidad);

        }
    }
}
