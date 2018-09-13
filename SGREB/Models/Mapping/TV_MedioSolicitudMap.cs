using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_MedioSolicitudMap : EntityTypeConfiguration<TV_MedioSolicitud>
    {
        public TV_MedioSolicitudMap()
        {
            // Primary Key
            this.HasKey(t => t.idSolicitud);

            // Properties
            this.Property(t => t.medio)
                .IsFixedLength()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("TV_MedioSolicitud");
            this.Property(t => t.idSolicitud).HasColumnName("idSolicitud");
            this.Property(t => t.medio).HasColumnName("medio");
        }
    }
}
