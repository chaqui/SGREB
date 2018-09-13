using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TT_LugarMap : EntityTypeConfiguration<TT_Lugar>
    {
        public TT_LugarMap()
        {
            // Primary Key
            this.HasKey(t => t.idLugar);

            // Properties
            this.Property(t => t.direccion)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TT_Lugar");
            this.Property(t => t.idLugar).HasColumnName("idLugar");
            this.Property(t => t.direccion).HasColumnName("direccion");
            this.Property(t => t.institucion).HasColumnName("institucion");

            // Relationships
            this.HasOptional(t => t.TV_InstitucionDeSalud)
                .WithMany(t => t.TT_Lugar)
                .HasForeignKey(d => d.institucion);

        }
    }
}
