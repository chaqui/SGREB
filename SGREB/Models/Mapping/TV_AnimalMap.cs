using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_AnimalMap : EntityTypeConfiguration<TV_Animal>
    {
        public TV_AnimalMap()
        {
            // Primary Key
            this.HasKey(t => t.idAnimal);

            // Properties
            this.Property(t => t.tipo)
                .IsFixedLength()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("TV_Animal");
            this.Property(t => t.idAnimal).HasColumnName("idAnimal");
            this.Property(t => t.tipo).HasColumnName("tipo");
        }
    }
}
