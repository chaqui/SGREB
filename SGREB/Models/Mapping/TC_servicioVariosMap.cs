using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_servicioVariosMap : EntityTypeConfiguration<TC_servicioVarios>
    {
        public TC_servicioVariosMap()
        {
            // Primary Key
            this.HasKey(t => t.idServiciosVarios);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_servicioVarios");
            this.Property(t => t.idServiciosVarios).HasColumnName("idServiciosVarios");
            this.Property(t => t.tipoServicio).HasColumnName("tipoServicio");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");

            // Relationships
            this.HasRequired(t => t.TC_Incidente)
                .WithMany(t => t.TC_servicioVarios)
                .HasForeignKey(d => d.idIncidente);
            this.HasOptional(t => t.TV_TipoServicio)
                .WithMany(t => t.TC_servicioVarios)
                .HasForeignKey(d => d.tipoServicio);

        }
    }
}
