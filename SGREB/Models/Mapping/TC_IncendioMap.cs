using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_IncendioMap : EntityTypeConfiguration<TC_Incendio>
    {
        public TC_IncendioMap()
        {
            // Primary Key
            this.HasKey(t => t.idIncendio);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_Incendio");
            this.Property(t => t.idIncendio).HasColumnName("idIncendio");
            this.Property(t => t.perdidas).HasColumnName("perdidas");
            this.Property(t => t.aguaUtilizada).HasColumnName("aguaUtilizada");
            this.Property(t => t.quemadosVivos).HasColumnName("quemadosVivos");
            this.Property(t => t.quemadosFallecidos).HasColumnName("quemadosFallecidos");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");
            this.Property(t => t.propietario).HasColumnName("propietario");

            // Relationships
            this.HasRequired(t => t.TC_Incidente)
                .WithMany(t => t.TC_Incendio)
                .HasForeignKey(d => d.idIncidente);
            this.HasOptional(t => t.TC_Persona)
                .WithMany(t => t.TC_Incendio)
                .HasForeignKey(d => d.propietario);

        }
    }
}
