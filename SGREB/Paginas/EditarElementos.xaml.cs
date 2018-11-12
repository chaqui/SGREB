using SGREB.Controlador;
using SGREB.Formularios;
using SGREB.miscellany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGREB.Paginas
{
    /// <summary>
    /// Lógica de interacción para EditarElementos.xaml
    /// </summary>
    public partial class EditarElementos : UserControl
    {
        private string tipo;
        private List<BomberoComboBox> elementos = new List<BomberoComboBox>();
        public EditarElementos(string tipo)
        {
            this.tipo = tipo;
            InitializeComponent();
            if (tipo == "animal")
            {
                obtenerAnimales();
            }
            else if (tipo == "CausaEnfermedadComun")
            {
                obtenerEnfermedadesComunes();
            } else if (tipo == "causaIntoxicacion")
            {
                obtenerCausasDeIntoxicacion();
            } else if (tipo == "causaSuicidio")
            {
                obtenerCausasSuicidio();

            } else if (tipo == "grado")
            {
                obtenerGrado();

            } else if (tipo == "medioSolicitud")
            {
                obtenerMedioSolicitud();
            } else if (tipo == "rol")
            {
                obtenerRoles();
            } else if (tipo == "tipoServicio")
            {
                obtenerTiposDeServicio();
            } else if (tipo == "tipoUnidad")
            {
                obtenerTiposUnidad();
            } else if (tipo == "tipoVehiculo")
            {
                obtenerTiposDeVehiculo();
            }
            actualizarGrid();

        }

        private void obtenerTiposDeVehiculo()
        {
            elementos.Clear();
            TipoVehiculo tipoVehiculo = new TipoVehiculo();
            var resultado = tipoVehiculo.obtenerVarios();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idTipoVehiculo.ToString(), nombre = r.tipo });
            }
        }

        private void obtenerTiposUnidad()
        {
            elementos.Clear();
            TipoUnidad causaEnfermedad = new TipoUnidad();
            var resultado = causaEnfermedad.obtenerVasrios();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idTipoUnidad.ToString(), nombre = r.nombreTipo });
            }
        }

        private void obtenerTiposDeServicio()
        {
            elementos.Clear();
            TipoServicio tipoServicio = new TipoServicio();
            var resultado = tipoServicio.obtenerTodos();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idTipoServicio.ToString(), nombre = r.nombre });
            }
        }

        private void obtenerRoles()
        {
            elementos.Clear();
            Controlador.Rol rol = new Controlador.Rol();
            var resultado = rol.obtenerVarios();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idRol.ToString(), nombre = r.nombre });
            }
        }

        private void obtenerMedioSolicitud()
        {
            elementos.Clear();
            MedioSolicitud medioSolicitud = new MedioSolicitud();
            var resultado = medioSolicitud.obtenerTodos();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idSolicitud.ToString(), nombre = r.medio });
            }
        }

        private void obtenerGrado()
        {
            elementos.Clear();
            Grado grado = new Grado();
            var resultado = grado.obtenerVarios();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idGrado.ToString(), nombre = r.nombreGrado });
            }
        }
        private void obtenerCausasSuicidio()
        {
            elementos.Clear();
            CausaSuicidio causaSuicidio = new CausaSuicidio();
            var resultado = causaSuicidio.obtenerTodos();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idCausa.ToString(), nombre = r.CausaSuicidio });
            }

        }

        private void obtenerCausasDeIntoxicacion()
        {
            elementos.Clear();
            CausaIntoxicacion causaIntoxicacion = new CausaIntoxicacion();
            var resultado = causaIntoxicacion.obtenerTodos();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idCausaIntoxicacion.ToString(), nombre = r.nombre });
            }

        }
        private void obtenerEnfermedadesComunes()
        {
            elementos.Clear();
            CausaEnfermedadComun causaEnfermedad = new CausaEnfermedadComun();
            var resultado = causaEnfermedad.obtenerTodos();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idCausa.ToString(), nombre = r.nombre });
            }
        }

        private void obtenerAnimales()
        {
            elementos.Clear();
            Animal animal = new Animal();
            var resultado = animal.obtenerVarios();
            foreach (var r in resultado)
            {
                elementos.Add(new BomberoComboBox { id = r.idAnimal.ToString(), nombre = r.tipo });
            }
        }

        private void actualizarGrid()
        {
            dgUnidades.Items.Clear();
            foreach (var elemento in elementos)
            {
                dgUnidades.Items.Add(elemento);
            }
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {

            var r = MessageBox.Show("Desea eliminar este elemento", "Precaución", MessageBoxButton.OKCancel);
            if( r == MessageBoxResult.Cancel)
            {
                return;
            }
            try { 
                if (tipo == "animal")
                {
                    Animal animal = new Animal();
                    var seleccionado =(BomberoComboBox) dgUnidades.SelectedItem;
                    animal.eliminar(int.Parse(seleccionado.id));
                    obtenerAnimales();
                }
                else if (tipo == "CausaEnfermedadComun")
                {
                    Animal animal = new Animal();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    animal.eliminar(int.Parse(seleccionado.id));
                    obtenerEnfermedadesComunes();
                }
                else if (tipo == "causaIntoxicacion")
                {
                    CausaIntoxicacion causa = new CausaIntoxicacion();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    causa.eliminar(int.Parse(seleccionado.id));
                    obtenerCausasDeIntoxicacion();

                }
                else if (tipo == "causaSuicidio")
                {
                    CausaSuicidio causa = new CausaSuicidio();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    causa.eliminar(int.Parse(seleccionado.id));
                    obtenerCausasSuicidio();
                }
                else if (tipo == "grado")
                {
                    Grado grado = new Grado();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    grado.eliminar(int.Parse(seleccionado.id));
                    obtenerGrado();

                }
                else if (tipo == "medioSolicitud")
                {
                    MedioSolicitud medio = new MedioSolicitud();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    medio.eliminar(int.Parse(seleccionado.id));
                    obtenerMedioSolicitud();
                }
                else if (tipo == "rol")
                {
                    MedioSolicitud medio = new MedioSolicitud();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    medio.eliminar(int.Parse(seleccionado.id));
                    obtenerRoles();
                }
                else if (tipo == "tipoServicio")
                {
                    TipoServicio tipoServicio = new TipoServicio();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    tipoServicio.eliminar(int.Parse(seleccionado.id));
                    obtenerTiposDeServicio();
                }
                else if (tipo == "tipoUnidad")
                {
                    TipoUnidad tipoUnidad = new TipoUnidad();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    tipoUnidad.eliminar(int.Parse(seleccionado.id));
                    obtenerTiposUnidad();
                }
                else if (tipo == "tipoVehiculo")
                {
                    TipoVehiculo tipoUnidad = new TipoVehiculo();
                    var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                    tipoUnidad.eliminar(int.Parse(seleccionado.id));
                    obtenerTiposDeVehiculo();
                }
            }
            catch
            {
                MessageBox.Show("No se puede eliminar solo editar");
                return;
            }
            actualizarGrid();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "animal")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                AnimalForm form = new AnimalForm(int.Parse( seleccionado.id));
                form.ShowDialog();
                obtenerAnimales();

            }
            else if (tipo == "CausaEnfermedadComun")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                CausaEnfermedadComunForm form = new CausaEnfermedadComunForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerEnfermedadesComunes();

            }
            else if (tipo == "causaIntoxicacion")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                IntoxicacionForm form = new IntoxicacionForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerCausasDeIntoxicacion();

            }
            else if (tipo == "causaSuicidio")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                CausaSuicidioForm form = new CausaSuicidioForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerCausasSuicidio();
            }
            else if (tipo == "grado")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                GradoForm form = new GradoForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerGrado();

            }
            else if (tipo == "medioSolicitud")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                MedioForm form = new MedioForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerMedioSolicitud();
            }
            else if (tipo == "rol")
            {

                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                Formularios.Rol form = new Formularios.Rol(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerRoles();
            }
            else if (tipo == "tipoServicio")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                TipoServicioVariosForm form = new TipoServicioVariosForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerTiposDeServicio();
            }
            else if (tipo == "tipoUnidad")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                TipoUnidadForm form = new TipoUnidadForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerTiposUnidad();
            }
            else if (tipo == "tipoVehiculo")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                VehiculoForm form = new VehiculoForm(int.Parse(seleccionado.id));
                form.ShowDialog();
                obtenerTiposUnidad();
            }
        }

        private void btCrear_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "animal")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                AnimalForm form = new AnimalForm();
                form.ShowDialog();
                obtenerAnimales();

            }
            else if (tipo == "CausaEnfermedadComun")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                CausaEnfermedadComunForm form = new CausaEnfermedadComunForm();
                form.ShowDialog();
                obtenerEnfermedadesComunes();

            }
            else if (tipo == "causaIntoxicacion")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                IntoxicacionForm form = new IntoxicacionForm();
                form.ShowDialog();
                obtenerCausasDeIntoxicacion();

            }
            else if (tipo == "causaSuicidio")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                CausaSuicidioForm form = new CausaSuicidioForm();
                form.ShowDialog();
                obtenerCausasSuicidio();
            }
            else if (tipo == "grado")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                GradoForm form = new GradoForm();
                form.ShowDialog();
                obtenerGrado();

            }
            else if (tipo == "medioSolicitud")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                MedioForm form = new MedioForm();
                form.ShowDialog();
                obtenerMedioSolicitud();
            }
            else if (tipo == "rol")
            {

                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                Formularios.Rol form = new Formularios.Rol();
                form.ShowDialog();
                obtenerRoles();
            }
            else if (tipo == "tipoServicio")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                TipoServicioVariosForm form = new TipoServicioVariosForm();
                form.ShowDialog();
                obtenerTiposDeServicio();
            }
            else if (tipo == "tipoUnidad")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                TipoUnidadForm form = new TipoUnidadForm();
                form.ShowDialog();
                obtenerTiposUnidad();
            }
            else if (tipo == "tipoVehiculo")
            {
                var seleccionado = (BomberoComboBox)dgUnidades.SelectedItem;
                VehiculoForm form = new VehiculoForm();
                form.ShowDialog();
                obtenerTiposUnidad();
            }
            actualizarGrid();
        }
    }
}
