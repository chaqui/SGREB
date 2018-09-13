using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SGREB.Models.Mapping
{
    public class TC_PacienteMap : EntityTypeConfiguration<TC_Paciente>
    {
        public TC_PacienteMap()
        {
            // Primary Key
            this.HasKey(t => t.idPaciente);

            // Properties
            this.Property(t => t.idPaciente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Sexo)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("TC_Paciente");
            this.Property(t => t.idPaciente).HasColumnName("idPaciente");
            this.Property(t => t.edad).HasColumnName("edad");
            this.Property(t => t.Sexo).HasColumnName("Sexo");
            this.Property(t => t.fallecido).HasColumnName("fallecido");
            this.Property(t => t.Persoan).HasColumnName("Persoan");
            this.Property(t => t.herido).HasColumnName("herido");

            // Relationships
            this.HasMany(t => t.TV_Animal)
                .WithMany(t => t.TC_Paciente)
                .Map(m =>
                    {
                        m.ToTable("TC_PacienteMordido");
                        m.MapLeftKey("idPaciente");
                        m.MapRightKey("animal");
                    });

            this.HasMany(t => t.TV_CausaIntoxicacion)
                .WithMany(t => t.TC_Paciente)
                .Map(m =>
                    {
                        m.ToTable("TCPacienteIntoxicado");
                        m.MapLeftKey("idPaciente");
                        m.MapRightKey("causa");
                    });

            this.HasMany(t => t.TC_Persona1)
                .WithMany(t => t.TC_Paciente1)
                .Map(m =>
                    {
                        m.ToTable("TT_AcompañanteDePaciente");
                        m.MapLeftKey("idPaciente");
                        m.MapRightKey("idAcompañante");
                    });

            this.HasOptional(t => t.TC_Persona)
                .WithMany(t => t.TC_Paciente)
                .HasForeignKey(d => d.Persoan);

        }
    }
}
