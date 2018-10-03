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

namespace SGREB.Paginas.administrador
{
    /// <summary>
    /// Lógica de interacción para UnidadesControl.xaml
    /// </summary>
    public partial class UnidadesControl : UserControl
    {
        /// <summary>
        /// constructor del formulario
        /// </summary>
        public UnidadesControl()
        {
            InitializeComponent();
            obtenerUnidades();
        }

        /// <summary>
        /// obtener todas las unidades almacenadas 
        /// e ingresarlas en el Data Grid
        /// </summary>
        private void obtenerUnidades()
        {
            if(dataGridUnidades.Items.Count >0)
            {
                dataGridUnidades.Items.Clear();
            }
            Unidad unidad = new Unidad();
            var unidades = unidad.obtenerVarios();
            // si existe alguna unidad
            if (unidades.Count > 0)
            {
                ///procesos para ingresarlos al data Grid
                foreach (var un in unidades)
                {
                    var tipoUnidad = new TipoUnidad();
                    var tipo = tipoUnidad.obtener(un.tipo);
                    var elemento = new UnidadDataGrid { placa = un.placa, tipo = tipo.nombreTipo, estado = unidad.obtenerEstado(un.estado) };
                    dataGridUnidades.Items.Add(elemento);
                }
            }

            //si no existe se muestra un mensaje en el data grid
            else
            {
                var elemeto = new UnidadDataGrid { placa = "no existe ninguna unidad.." };
                dataGridUnidades.Items.Add(elemeto);
            }
        }

 

        private void btAgregarElemento_Click(object sender, RoutedEventArgs e)
        {
            try { 
            UnidadForm unidadForm = new UnidadForm();
            unidadForm.ShowDialog();
            obtenerUnidades();
            }
            catch
            {

            }
        }

        private void btModificarElemento_Click(object sender, RoutedEventArgs e)
        {
            var seleccionado = (UnidadDataGrid)dataGridUnidades.SelectedItem;

            UnidadForm unidadForm = new UnidadForm(seleccionado.placa);
            unidadForm.ShowDialog();
            obtenerUnidades();
        }
    }
}
