using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_CertificacionMap : EntityTypeConfiguration<TC_Certificacion>
    {
        public TC_CertificacionMap()
        {
            // Primary Key
            this.HasKey(t => t.idCertificacion);

            // Properties
            this.Property(t => t.solicitante)
                .IsFixedLength()
                .HasMaxLength(75);

            this.Property(t => t.profesion)
                .IsFixedLength()
                .HasMaxLength(75);

            // Table & Column Mappings
            this.ToTable("TC_Certificacion");
            this.Property(t => t.idCertificacion).HasColumnName("idCertificacion");
            this.Property(t => t.solicitante).HasColumnName("solicitante");
            this.Property(t => t.profesion).HasColumnName("profesion");
            this.Property(t => t.idSolicitud).HasColumnName("idSolicitud");
            this.Property(t => t.fecha).HasColumnName("fecha");

            // Relationships
            this.HasOptional(t => t.TC_Solicitud)
                .WithMany(t => t.TC_Certificacion)
                .HasForeignKey(d => d.idSolicitud);

        }
    }
}
