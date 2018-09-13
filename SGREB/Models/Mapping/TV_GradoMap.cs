using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_GradoMap : EntityTypeConfiguration<TV_Grado>
    {
        public TV_GradoMap()
        {
            // Primary Key
            this.HasKey(t => t.idGrado);

            // Properties
            this.Property(t => t.nombreGrado)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TV_Grado");
            this.Property(t => t.idGrado).HasColumnName("idGrado");
            this.Property(t => t.nombreGrado).HasColumnName("nombreGrado");
        }
    }
}
