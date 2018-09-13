using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_ViviendaInundadaMap : EntityTypeConfiguration<TC_ViviendaInundada>
    {
        public TC_ViviendaInundadaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdViviendaInundada);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_ViviendaInundada");
            this.Property(t => t.IdViviendaInundada).HasColumnName("IdViviendaInundada");
            this.Property(t => t.propietario).HasColumnName("propietario");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");

            // Relationships
            this.HasOptional(t => t.TC_Incidente)
                .WithMany(t => t.TC_ViviendaInundada)
                .HasForeignKey(d => d.idIncidente);
            this.HasOptional(t => t.TC_Persona)
                .WithMany(t => t.TC_ViviendaInundada)
                .HasForeignKey(d => d.propietario);

        }
    }
}
