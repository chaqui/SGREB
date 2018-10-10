using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_CausaEnfermedadComunMap : EntityTypeConfiguration<TV_CausaEnfermedadComun>
    {
        public TV_CausaEnfermedadComunMap()
        {
            // Primary Key
            this.HasKey(t => t.idCausa);

            // Properties
            this.Property(t => t.nombre)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TV_CausaEnfermedadComun");
            this.Property(t => t.idCausa).HasColumnName("idCausa");
            this.Property(t => t.nombre).HasColumnName("nombre");
        }
    }
}
