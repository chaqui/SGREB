using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_TipoUnidadMap : EntityTypeConfiguration<TV_TipoUnidad>
    {
        public TV_TipoUnidadMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipoUnidad);

            // Properties
            this.Property(t => t.idTipoUnidad)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nombreTipo)
                .IsFixedLength()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TV_TipoUnidad");
            this.Property(t => t.idTipoUnidad).HasColumnName("idTipoUnidad");
            this.Property(t => t.nombreTipo).HasColumnName("nombreTipo");
        }
    }
}
