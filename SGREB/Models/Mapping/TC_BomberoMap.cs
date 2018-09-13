using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_BomberoMap : EntityTypeConfiguration<TC_Bombero>
    {
        public TC_BomberoMap()
        {
            // Primary Key
            this.HasKey(t => t.idBombero);

            // Properties
            this.Property(t => t.idBombero)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TC_Bombero");
            this.Property(t => t.idBombero).HasColumnName("idBombero");
            this.Property(t => t.persona).HasColumnName("persona");
            this.Property(t => t.rol).HasColumnName("rol");
            this.Property(t => t.grado).HasColumnName("grado");

            // Relationships
            this.HasMany(t => t.TC_Incidente)
                .WithMany(t => t.TC_Bombero)
                .Map(m =>
                    {
                        m.ToTable("TC_PersonalIncidente");
                        m.MapLeftKey("idBombero");
                        m.MapRightKey("idIncidente");
                    });

            this.HasRequired(t => t.TC_Persona)
                .WithMany(t => t.TC_Bombero)
                .HasForeignKey(d => d.persona);
            this.HasOptional(t => t.TV_Grado)
                .WithMany(t => t.TC_Bombero)
                .HasForeignKey(d => d.grado);
            this.HasOptional(t => t.TV_Rol)
                .WithMany(t => t.TC_Bombero)
                .HasForeignKey(d => d.rol);

        }
    }
}
