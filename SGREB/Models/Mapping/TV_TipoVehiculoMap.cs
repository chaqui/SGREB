using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_TipoVehiculoMap : EntityTypeConfiguration<TV_TipoVehiculo>
    {
        public TV_TipoVehiculoMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipoVehiculo);

            // Properties
            this.Property(t => t.tipo)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TV_TipoVehiculo");
            this.Property(t => t.idTipoVehiculo).HasColumnName("idTipoVehiculo");
            this.Property(t => t.tipo).HasColumnName("tipo");
        }
    }
}
