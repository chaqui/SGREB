using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_TipoServicioMap : EntityTypeConfiguration<TV_TipoServicio>
    {
        public TV_TipoServicioMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipoServicio);

            // Properties
            this.Property(t => t.nombre)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TV_TipoServicio");
            this.Property(t => t.idTipoServicio).HasColumnName("idTipoServicio");
            this.Property(t => t.nombre).HasColumnName("nombre");
        }
    }
}
