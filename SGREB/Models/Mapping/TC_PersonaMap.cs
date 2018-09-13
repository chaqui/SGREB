using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_PersonaMap : EntityTypeConfiguration<TC_Persona>
    {
        public TC_PersonaMap()
        {
            // Primary Key
            this.HasKey(t => t.idPersona);

            // Properties
            this.Property(t => t.nombres)
                .IsFixedLength()
                .HasMaxLength(45);

            this.Property(t => t.apellidos)
                .IsFixedLength()
                .HasMaxLength(45);

            this.Property(t => t.dpi)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("TC_Persona");
            this.Property(t => t.idPersona).HasColumnName("idPersona");
            this.Property(t => t.nombres).HasColumnName("nombres");
            this.Property(t => t.apellidos).HasColumnName("apellidos");
            this.Property(t => t.dpi).HasColumnName("dpi");
        }
    }
}
