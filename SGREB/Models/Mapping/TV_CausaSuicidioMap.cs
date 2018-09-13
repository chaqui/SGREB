using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TV_CausaSuicidioMap : EntityTypeConfiguration<TV_CausaSuicidio>
    {
        public TV_CausaSuicidioMap()
        {
            // Primary Key
            this.HasKey(t => t.idCausa);

            // Properties
            this.Property(t => t.CausaSuicidio)
                .IsFixedLength()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TV_CausaSuicidio");
            this.Property(t => t.idCausa).HasColumnName("idCausa");
            this.Property(t => t.CausaSuicidio).HasColumnName("CausaSuicidio");
        }
    }
}
