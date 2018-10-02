using SGREB.Controlador;
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
using System.Windows.Shapes;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para UnidadPilotoForm.xaml
    /// </summary>
    public partial class UnidadPilotoForm : Window

    {
        private List<UniidadIncidenteForm> unidadParaInicidentes;
        public UniidadIncidenteForm unidadPiloto;

        public UnidadPilotoForm()
        {
          
            InitializeComponent();
            unidadParaInicidentes = new List<UniidadIncidenteForm>();
            Persona persona = new Persona();
            unidadPiloto = new UniidadIncidenteForm();
            Controlador.Bombero bombero = new Controlador.Bombero();
            var bomberos = bombero.obtenerVarios();
            foreach ( var b in bomberos)
            {
                var p = persona.obtener(b.persona);
                unidadParaInicidentes.Add(new UniidadIncidenteForm { nombreBOmbero = p.nombres + " " + p.apellidos, idBombero = b.idBombero });
            }

            foreach ( var u in unidadParaInicidentes)
            {
                cmbPiloto.Items.Add(u.nombreBOmbero);
            }

            Unidad unidad = new Unidad();
            var unidades = unidad.obtenerVarios();
            foreach(var u in unidades)
            {
                cmbUnidad.Items.Add(u.placa);
            }
           
        }

        
        /// <summary>
        /// guarfar unidad con piloto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            var piloto = cmbPiloto.SelectedItem.ToString();
            var placa = cmbUnidad.SelectedItem.ToString();
            if (piloto == "")
            {
                return;
            }
            foreach (var u in unidadParaInicidentes)
            {
                if(u.nombreBOmbero == piloto)
                {
                    unidadPiloto = u;
                    unidadPiloto.idUnidad = placa;
                }
                 
            }
        }

        /// <summary>
        /// cancelar ( se cierra el formulario)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
