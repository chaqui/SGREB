using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_ClaseServicioMap : EntityTypeConfiguration<TV_ClaseServicio>
    {
        public TV_ClaseServicioMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nombre)
                .IsFixedLength()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("TV_ClaseServicio");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nombre).HasColumnName("nombre");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");

            // Relationships
            this.HasOptional(t => t.TC_Incidente)
                .WithMany(t => t.TV_ClaseServicio)
                .HasForeignKey(d => d.idIncidente);

        }
    }
}
