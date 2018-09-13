using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_SolicitudMap : EntityTypeConfiguration<TC_Solicitud>
    {
        public TC_SolicitudMap()
        {
            // Primary Key
            this.HasKey(t => t.idSolicitud);

            // Properties
            this.Property(t => t.radioTelefonista)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.ingresadoPor)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TC_Solicitud");
            this.Property(t => t.idSolicitud).HasColumnName("idSolicitud");
            this.Property(t => t.medioSolicitud).HasColumnName("medioSolicitud");
            this.Property(t => t.solicitante).HasColumnName("solicitante");
            this.Property(t => t.radioTelefonista).HasColumnName("radioTelefonista");
            this.Property(t => t.ingresadoPor).HasColumnName("ingresadoPor");
            this.Property(t => t.TraspasoACBM).HasColumnName("TraspasoACBM");

            // Relationships
            this.HasOptional(t => t.TC_Bombero)
                .WithMany(t => t.TC_Solicitud)
                .HasForeignKey(d => d.radioTelefonista);
            this.HasOptional(t => t.TC_Persona)
                .WithMany(t => t.TC_Solicitud)
                .HasForeignKey(d => d.solicitante);
            this.HasOptional(t => t.TC_Usuario)
                .WithMany(t => t.TC_Solicitud)
                .HasForeignKey(d => d.ingresadoPor);
            this.HasRequired(t => t.TV_MedioSolicitud)
                .WithMany(t => t.TC_Solicitud)
                .HasForeignKey(d => d.medioSolicitud);

        }
    }
}
