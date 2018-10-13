using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class PacienteDeIncidenteMap : EntityTypeConfiguration<PacienteDeIncidente>
    {
        public PacienteDeIncidenteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idPaciente, t.incidente });

            // Properties
            this.Property(t => t.idPaciente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.incidente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PacienteDeIncidente");
            this.Property(t => t.idPaciente).HasColumnName("idPaciente");
            this.Property(t => t.incidente).HasColumnName("incidente");

            // Relationships
            this.HasRequired(t => t.TC_Paciente)
                .WithMany(t => t.PacienteDeIncidentes)
                .HasForeignKey(d => d.idPaciente);

        }
    }
}
