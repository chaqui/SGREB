using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_CausaIntoxicacionMap : EntityTypeConfiguration<TV_CausaIntoxicacion>
    {
        public TV_CausaIntoxicacionMap()
        {
            // Primary Key
            this.HasKey(t => t.idCausaIntoxicacion);

            // Properties
            this.Property(t => t.nombre)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TV_CausaIntoxicacion");
            this.Property(t => t.idCausaIntoxicacion).HasColumnName("idCausaIntoxicacion");
            this.Property(t => t.nombre).HasColumnName("nombre");
        }
    }
}
