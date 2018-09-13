using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_TipoIncidenteMap : EntityTypeConfiguration<TV_TipoIncidente>
    {
        public TV_TipoIncidenteMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipo);

            // Properties
            this.Property(t => t.nombre)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TV_TipoIncidente");
            this.Property(t => t.idTipo).HasColumnName("idTipo");
            this.Property(t => t.nombre).HasColumnName("nombre");
        }
    }
}
