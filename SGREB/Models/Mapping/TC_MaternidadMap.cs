using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_MaternidadMap : EntityTypeConfiguration<TC_Maternidad>
    {
        public TC_MaternidadMap()
        {
            // Primary Key
            this.HasKey(t => t.idMaternidad);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_Maternidad");
            this.Property(t => t.idMaternidad).HasColumnName("idMaternidad");
            this.Property(t => t.aborto).HasColumnName("aborto");
            this.Property(t => t.atencionDeParto).HasColumnName("atencionDeParto");
            this.Property(t => t.RetencionDePlacenta).HasColumnName("RetencionDePlacenta");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");
            this.Property(t => t.mesesDeEmbarazo).HasColumnName("mesesDeEmbarazo");

            // Relationships
            this.HasRequired(t => t.TC_Incidente)
                .WithMany(t => t.TC_Maternidad)
                .HasForeignKey(d => d.idIncidente);

        }
    }
}
