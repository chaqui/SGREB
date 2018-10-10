using SGREB.Controlador;
using SGREB.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para UnidadForm.xaml
    /// </summary>
    public partial class UnidadForm : Window
    {
        private int tipo;
        private string placa;
        private List<TV_TipoUnidad> tipos;
        private string[] estados; 

        /// <summary>
        /// constructor para crear Unidad
        /// </summary>
        public UnidadForm()
        {
            InitializeComponent();
            tipo = 1;
            obtenerTipos();
            obtenerEstados();
        }

        /// <summary>
        /// constructor para actualizar Unidad
        /// </summary>
        /// <param name="placa"></param>
        public UnidadForm(string placa)
        {
            tipo = 2;
            this.placa = placa;
            InitializeComponent();
            obtenerTipos();
            obtenerEstados();

            Unidad unidad = new Unidad();
            lbTitulo.Text = "Actualizar Unidad";
            var u = unidad.obtener(placa);
            txPlaca.Text = placa;
            TipoUnidad tipoUnidad = new TipoUnidad();
            var t = tipoUnidad.obtener(u.tipo);
            var e = unidad.obtenerEstado(u.estado);
            cmbTipo.SelectedValue = t.nombreTipo;
            cmbEstado.SelectedValue = e;
            txPlaca.IsEnabled = false;

        }

        /// <summary>
        /// obtener los tipos de unudad e ingresarlos al comboBox
        /// </summary>
        private void obtenerTipos()
        {
            TipoUnidad tipoUnidad = new TipoUnidad();
            tipos = tipoUnidad.obtenerVasrios();
            if(cmbTipo.Items.Count > 0)
            {
                cmbTipo.Items.Clear();
            }
            foreach (var tip in tipos)
            {
                cmbTipo.Items.Add(tip.nombreTipo);
            }
            cmbTipo.Items.Add("Crear un nuevo tipo...");
        }

        /// <summary>
        /// obtener los estados y guardarlos en el comboBox
        /// </summary>
        private void obtenerEstados()
        {
            Unidad unidad = new Unidad();
            estados = unidad.obtenerEstados();
            foreach(var estado in estados)
            {
                cmbEstado.Items.Add(estado);
            }
        }

        /// <summary>
        /// evento de dar click en el boton guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            var placa = txPlaca.Text;
            if (placa == "")
            {
                MessageBox.Show("no a ingresado el numero de Placa");
                return;
            }
            int estadoId = obteneridEstado(cmbEstado.SelectedItem.ToString());
            if (estadoId == -1)
            {
                MessageBox.Show("no selecciono ningun estado", "error de ingreso");
                return;
            }

            int tipoId = obtenerIdTipo(cmbTipo.SelectedItem.ToString());

            if (tipoId == -1)
            {
                MessageBox.Show("no selecciono ningun tipo", "error de ingreso");
                return;
            }

            //guardar
            if(tipo == 1)
            {
            Unidad unidad = new Unidad();
            TC_Unidad tcUnidad = new TC_Unidad { placa = placa, estado = estadoId, tipo = tipoId };
            unidad.crear(tcUnidad);
            }

            //actualizar
            else
            {
                Unidad unidad = new Unidad();
                TC_Unidad tcUnidad = new TC_Unidad { placa = placa, estado = estadoId, tipo = tipoId };
                unidad.modificar(tcUnidad);
            }
            this.Close();
            
        }


        /// <summary>
        /// evento para guardar la nueva unidad
        /// </summary>
        private void guardar()
        {
           
        }

        private int obtenerIdTipo(string nombre)
        {
            foreach (var t in tipos)
            {
                if(t.nombreTipo == nombre)
                {
                    MessageBox.Show(nombre);
                    return t.idTipoUnidad;
                }
            }
            return -1;
        }

        private int obteneridEstado(string nombre)
        {
            for (int i = 0; i < estados.Length; i++)
            {
                if(estados[i] == nombre)
                {
                    return i;
                }
            }
            return -1;
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbTipo.SelectedItem.ToString() == "Crear un nuevo tipo...")
                {
                    TipoUnidadForm tipoUnidadForm = new TipoUnidadForm();
                    tipoUnidadForm.ShowDialog();
                    obtenerTipos();
                }
            }
            catch
            {

            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
