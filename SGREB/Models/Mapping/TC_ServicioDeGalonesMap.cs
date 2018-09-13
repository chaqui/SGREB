using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_ServicioDeGalonesMap : EntityTypeConfiguration<TC_ServicioDeGalones>
    {
        public TC_ServicioDeGalonesMap()
        {
            // Primary Key
            this.HasKey(t => t.idServicio);

            // Properties
            this.Property(t => t.idServicio)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TC_ServicioDeGalones");
            this.Property(t => t.idServicio).HasColumnName("idServicio");
            this.Property(t => t.Galones).HasColumnName("Galones");
            this.Property(t => t.idIncidente).HasColumnName("idIncidente");

            // Relationships
            this.HasOptional(t => t.TC_Incidente)
                .WithMany(t => t.TC_ServicioDeGalones)
                .HasForeignKey(d => d.idIncidente);

        }
    }
}
