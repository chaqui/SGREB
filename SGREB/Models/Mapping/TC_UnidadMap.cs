using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_UnidadMap : EntityTypeConfiguration<TC_Unidad>
    {
        public TC_UnidadMap()
        {
            // Primary Key
            this.HasKey(t => t.placa);

            // Properties
            this.Property(t => t.placa)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TC_Unidad");
            this.Property(t => t.placa).HasColumnName("placa");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.tipo).HasColumnName("tipo");

            // Relationships
            this.HasOptional(t => t.TV_TipoUnidad)
                .WithMany(t => t.TC_Unidad)
                .HasForeignKey(d => d.tipo);

        }
    }
}
