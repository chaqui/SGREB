using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_RolMap : EntityTypeConfiguration<TV_Rol>
    {
        public TV_RolMap()
        {
            // Primary Key
            this.HasKey(t => t.idRol);

            // Properties
            this.Property(t => t.nombre)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TV_Rol");
            this.Property(t => t.idRol).HasColumnName("idRol");
            this.Property(t => t.nombre).HasColumnName("nombre");
        }
    }
}
