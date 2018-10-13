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
            this.Property(t => t.formuladioPor)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.PilotoConforme)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.JefeDeServicio)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TC_Incidente");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");
            this.Property(t => t.tipoIncidente).HasColumnName("tipoIncidente");
            this.Property(t => t.lugar).HasColumnName("lugar");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.solicitud).HasColumnName("solicitud");
            this.Property(t => t.HoraEntrada).HasColumnName("HoraEntrada");
            this.Property(t => t.horaSalida).HasColumnName("horaSalida");
            this.Property(t => t.observaciones).HasColumnName("observaciones");
            this.Property(t => t.LugarTraslado).HasColumnName("LugarTraslado");
            this.Property(t => t.formuladioPor).HasColumnName("formuladioPor");
            this.Property(t => t.PilotoConforme).HasColumnName("PilotoConforme");
            this.Property(t => t.JefeDeServicio).HasColumnName("JefeDeServicio");

            // Relationships
            this.HasMany(t => t.TV_CausaEnfermedadComun)
                .WithMany(t => t.TC_Incidente)
                .Map(m =>
                    {
                        m.ToTable("TC_EnfermedadComun");
                        m.MapLeftKey("idIncidente");
                        m.MapRightKey("IdCausa");
                    });

            this.HasOptional(t => t.TC_Bombero)
                .WithMany(t => t.TC_Incidente)
                .HasForeignKey(d => d.formuladioPor);
            this.HasOptional(t => t.TC_Bombero1)
                .WithMany(t => t.TC_Incidente1)
                .HasForeignKey(d => d.PilotoConforme);
            this.HasOptional(t => t.TC_Bombero2)
                .WithMany(t => t.TC_Incidente2)
                .HasForeignKey(d => d.JefeDeServicio);
            this.HasOptional(t => t.TC_Solicitud)
                .WithMany(t => t.TC_Incidente)
                .HasForeignKey(d => d.solicitud);
            this.HasOptional(t => t.TT_Lugar)
                .WithMany(t => t.TC_Incidente)
                .HasForeignKey(d => d.lugar);
            this.HasOptional(t => t.TT_Lugar1)
                .WithMany(t => t.TC_Incidente1)
                .HasForeignKey(d => d.LugarTraslado);
            this.HasOptional(t => t.TV_TipoIncidente)
                .WithMany(t => t.TC_Incidente)
                .HasForeignKey(d => d.tipoIncidente);

        }
    }
}
