using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_InstitucionDeSaludMap : EntityTypeConfiguration<TV_InstitucionDeSalud>
    {
        public TV_InstitucionDeSaludMap()
        {
            // Primary Key
            this.HasKey(t => t.idInstitucion);

            // Properties
            this.Property(t => t.nombre)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(75);

            // Table & Column Mappings
            this.ToTable("TV_InstitucionDeSalud");
            this.Property(t => t.idInstitucion).HasColumnName("idInstitucion");
            this.Property(t => t.nombre).HasColumnName("nombre");
        }
    }
}
