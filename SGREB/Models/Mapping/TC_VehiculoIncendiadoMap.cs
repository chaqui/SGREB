using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_VehiculoIncendiadoMap : EntityTypeConfiguration<TC_VehiculoIncendiado>
    {
        public TC_VehiculoIncendiadoMap()
        {
            // Primary Key
            this.HasKey(t => t.idVehiculoIncendiado);

            // Properties
            this.Property(t => t.idVehiculoIncendiado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.vehiculo)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.placa)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TC_VehiculoIncendiado");
            this.Property(t => t.idVehiculoIncendiado).HasColumnName("idVehiculoIncendiado");
            this.Property(t => t.propietario).HasColumnName("propietario");
            this.Property(t => t.vehiculo).HasColumnName("vehiculo");
            this.Property(t => t.tipoVehiculo).HasColumnName("tipoVehiculo");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");
            this.Property(t => t.placa).HasColumnName("placa");

            // Relationships
            this.HasOptional(t => t.TC_Incidente)
                .WithMany(t => t.TC_VehiculoIncendiado)
                .HasForeignKey(d => d.idIncidente);
            this.HasOptional(t => t.TC_Persona)
                .WithMany(t => t.TC_VehiculoIncendiado)
                .HasForeignKey(d => d.propietario);
            this.HasOptional(t => t.TV_TipoVehiculo)
                .WithMany(t => t.TC_VehiculoIncendiado)
                .HasForeignKey(d => d.tipoVehiculo);

        }
    }
}
