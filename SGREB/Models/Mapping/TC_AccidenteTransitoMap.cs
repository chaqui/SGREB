using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_AccidenteTransitoMap : EntityTypeConfiguration<TC_AccidenteTransito>
    {
        public TC_AccidenteTransitoMap()
        {
            // Primary Key
            this.HasKey(t => t.idAccidente);

            // Properties
            this.Property(t => t.placa)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TC_AccidenteTransito");
            this.Property(t => t.idAccidente).HasColumnName("idAccidente");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");
            this.Property(t => t.tipoVehiculo).HasColumnName("tipoVehiculo");
            this.Property(t => t.placa).HasColumnName("placa");

            // Relationships
            this.HasRequired(t => t.TC_Incidente)
                .WithMany(t => t.TC_AccidenteTransito)
                .HasForeignKey(d => d.idIncidente);
            this.HasRequired(t => t.TV_TipoVehiculo)
                .WithMany(t => t.TC_AccidenteTransito)
                .HasForeignKey(d => d.tipoVehiculo);

        }
    }
}
