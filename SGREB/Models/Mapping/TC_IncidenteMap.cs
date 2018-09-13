using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_IncidenteMap : EntityTypeConfiguration<TC_Incidente>
    {
        public TC_IncidenteMap()
        {
            // Primary Key
            this.HasKey(t => t.idIncidente);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_Incidente");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");
            this.Property(t => t.tipoIncidente).HasColumnName("tipoIncidente");
            this.Property(t => t.lugar).HasColumnName("lugar");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.solicitud).HasColumnName("solicitud");
            this.Property(t => t.HoraEntrada).HasColumnName("HoraEntrada");
            this.Property(t => t.horaSalida).HasColumnName("horaSalida");

            // Relationships
            this.HasMany(t => t.TC_Paciente)
                .WithMany(t => t.TC_Incidente)
                .Map(m =>
                    {
                        m.ToTable("PacienteDeIncidente");
                        m.MapLeftKey("incidente");
                        m.MapRightKey("idPaciente");
                    });

            this.HasOptional(t => t.TC_Solicitud)
                .WithMany(t => t.TC_Incidente)
                .HasForeignKey(d => d.solicitud);
            this.HasOptional(t => t.TT_Lugar)
                .WithMany(t => t.TC_Incidente)
                .HasForeignKey(d => d.lugar);
            this.HasOptional(t => t.TV_TipoIncidente)
                .WithMany(t => t.TC_Incidente)
                .HasForeignKey(d => d.tipoIncidente);

        }
    }
}
