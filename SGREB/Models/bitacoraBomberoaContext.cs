using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SGREB.Models.Mapping;

namespace SGREB.Models
{
    public partial class bitacoraBomberoaContext : DbContext
    {
        static bitacoraBomberoaContext()
        {
            Database.SetInitializer<bitacoraBomberoaContext>(null);
        }

        public bitacoraBomberoaContext()
            : base("Name=bitacoraBomberoaContext")
        {
        }

        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TC_AccidenteTransito> TC_AccidenteTransito { get; set; }
        public DbSet<TC_Bombero> TC_Bombero { get; set; }
        public DbSet<TC_Certificacion> TC_Certificacion { get; set; }
        public DbSet<TC_HechoDeViolencia> TC_HechoDeViolencia { get; set; }
        public DbSet<TC_Incendio> TC_Incendio { get; set; }
        public DbSet<TC_Incidente> TC_Incidente { get; set; }
        public DbSet<TC_Maternidad> TC_Maternidad { get; set; }
        public DbSet<TC_Paciente> TC_Paciente { get; set; }
        public DbSet<TC_Persona> TC_Persona { get; set; }
        public DbSet<TC_Rastreo> TC_Rastreo { get; set; }
        public DbSet<TC_ServicioDeGalones> TC_ServicioDeGalones { get; set; }
        public DbSet<TC_servicioVarios> TC_servicioVarios { get; set; }
        public DbSet<TC_Solicitud> TC_Solicitud { get; set; }
        public DbSet<TC_Suicidio> TC_Suicidio { get; set; }
        public DbSet<TC_Unidad> TC_Unidad { get; set; }
        public DbSet<TC_UnidadParaIncidente> TC_UnidadParaIncidente { get; set; }
        public DbSet<TC_Usuario> TC_Usuario { get; set; }
        public DbSet<TC_VehiculoIncendiado> TC_VehiculoIncendiado { get; set; }
        public DbSet<TC_ViviendaInundada> TC_ViviendaInundada { get; set; }
        public DbSet<TT_EvacuadoInundacion> TT_EvacuadoInundacion { get; set; }
        public DbSet<TT_Lugar> TT_Lugar { get; set; }
        public DbSet<TV_Animal> TV_Animal { get; set; }
        public DbSet<TV_CausaEnfermedadComun> TV_CausaEnfermedadComun { get; set; }
        public DbSet<TV_CausaIntoxicacion> TV_CausaIntoxicacion { get; set; }
        public DbSet<TV_CausaSuicidio> TV_CausaSuicidio { get; set; }
        public DbSet<TV_Grado> TV_Grado { get; set; }
        public DbSet<TV_InstitucionDeSalud> TV_InstitucionDeSalud { get; set; }
        public DbSet<TV_MedioSolicitud> TV_MedioSolicitud { get; set; }
        public DbSet<TV_Rol> TV_Rol { get; set; }
        public DbSet<TV_TipoIncidente> TV_TipoIncidente { get; set; }
        public DbSet<TV_TipoServicio> TV_TipoServicio { get; set; }
        public DbSet<TV_TipoUnidad> TV_TipoUnidad { get; set; }
        public DbSet<TV_TipoVehiculo> TV_TipoVehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TC_AccidenteTransitoMap());
            modelBuilder.Configurations.Add(new TC_BomberoMap());
            modelBuilder.Configurations.Add(new TC_CertificacionMap());
            modelBuilder.Configurations.Add(new TC_HechoDeViolenciaMap());
            modelBuilder.Configurations.Add(new TC_IncendioMap());
            modelBuilder.Configurations.Add(new TC_IncidenteMap());
            modelBuilder.Configurations.Add(new TC_MaternidadMap());
            modelBuilder.Configurations.Add(new TC_PacienteMap());
            modelBuilder.Configurations.Add(new TC_PersonaMap());
            modelBuilder.Configurations.Add(new TC_RastreoMap());
            modelBuilder.Configurations.Add(new TC_ServicioDeGalonesMap());
            modelBuilder.Configurations.Add(new TC_servicioVariosMap());
            modelBuilder.Configurations.Add(new TC_SolicitudMap());
            modelBuilder.Configurations.Add(new TC_SuicidioMap());
            modelBuilder.Configurations.Add(new TC_UnidadMap());
            modelBuilder.Configurations.Add(new TC_UnidadParaIncidenteMap());
            modelBuilder.Configurations.Add(new TC_UsuarioMap());
            modelBuilder.Configurations.Add(new TC_VehiculoIncendiadoMap());
            modelBuilder.Configurations.Add(new TC_ViviendaInundadaMap());
            modelBuilder.Configurations.Add(new TT_EvacuadoInundacionMap());
            modelBuilder.Configurations.Add(new TT_LugarMap());
            modelBuilder.Configurations.Add(new TV_AnimalMap());
            modelBuilder.Configurations.Add(new TV_CausaEnfermedadComunMap());
            modelBuilder.Configurations.Add(new TV_CausaIntoxicacionMap());
            modelBuilder.Configurations.Add(new TV_CausaSuicidioMap());
            modelBuilder.Configurations.Add(new TV_GradoMap());
            modelBuilder.Configurations.Add(new TV_InstitucionDeSaludMap());
            modelBuilder.Configurations.Add(new TV_MedioSolicitudMap());
            modelBuilder.Configurations.Add(new TV_RolMap());
            modelBuilder.Configurations.Add(new TV_TipoIncidenteMap());
            modelBuilder.Configurations.Add(new TV_TipoServicioMap());
            modelBuilder.Configurations.Add(new TV_TipoUnidadMap());
            modelBuilder.Configurations.Add(new TV_TipoVehiculoMap());
        }
    }
}
