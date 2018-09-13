using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TT_EvacuadoInundacionMap : EntityTypeConfiguration<TT_EvacuadoInundacion>
    {
        public TT_EvacuadoInundacionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idViviendaInundada, t.IdEvacuado });

            // Properties
            this.Property(t => t.idViviendaInundada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdEvacuado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TT_EvacuadoInundacion");
            this.Property(t => t.idViviendaInundada).HasColumnName("idViviendaInundada");
            this.Property(t => t.IdEvacuado).HasColumnName("IdEvacuado");

            // Relationships
            this.HasRequired(t => t.TC_Paciente)
                .WithMany(t => t.TT_EvacuadoInundacion)
                .HasForeignKey(d => d.idViviendaInundada);
            this.HasRequired(t => t.TC_ViviendaInundada)
                .WithMany(t => t.TT_EvacuadoInundacion)
                .HasForeignKey(d => d.idViviendaInundada);

        }
    }
}
