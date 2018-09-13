using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_UsuarioMap : EntityTypeConfiguration<TC_Usuario>
    {
        public TC_UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.nickname);

            // Properties
            this.Property(t => t.nickname)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(45);

            this.Property(t => t.contrasenia)
                .IsFixedLength()
                .HasMaxLength(45);

            this.Property(t => t.bombero)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TC_Usuario");
            this.Property(t => t.nickname).HasColumnName("nickname");
            this.Property(t => t.contrasenia).HasColumnName("contrasenia");
            this.Property(t => t.bombero).HasColumnName("bombero");

            // Relationships
            this.HasOptional(t => t.TC_Bombero)
                .WithMany(t => t.TC_Usuario)
                .HasForeignKey(d => d.bombero);

        }
    }
}
