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

namespace SGREB
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            //Menu Inicial 
            MenuItem iniciarMenu = new MenuItem();
            iniciarMenu.Header = "Ingresar";
            MenuItem iniciarSesionMenu = new MenuItem();
            iniciarSesionMenu.Header = "Iniciar Sesion";
            iniciarMenu.Items.Add(iniciarSesionMenu);
            iniciarSesionMenu.Click += IniciarSesionMenu_Click;
            InitializeComponent();
            this.menu.Items.Add(iniciarMenu);
        }

        private void IniciarSesionMenu_Click(object sender, RoutedEventArgs e)
        {
            var n = new IniciarSesion();
            var r = n.ShowDialog();
            if (n.InicioDeSesion.ingreso)
            {
                this.menu.Items.Clear();
                if (n.InicioDeSesion.normal) {
                    menuNormal();
                }
                else
                { menuAdministrador(); }
            }
            
        }
        /// <summary>
        /// 
        /// </summary>

        private void menuAdministrador()
        {
            menuNormal();
            MenuItem administrarMenu = new MenuItem();
            administrarMenu.Header = "Administrar";

            MenuItem usuariosMenu = new MenuItem();
            usuariosMenu.Header = "usuarios";
            administrarMenu.Items.Add(usuariosMenu);

            MenuItem bomberosMenu = new MenuItem();
            bomberosMenu.Header = "Bomberos";
            administrarMenu.Items.Add(bomberosMenu);

            MenuItem unidadesMenu = new MenuItem();
            bomberosMenu.Header = "Unidades";
            unidadesMenu.Items.Add(unidadesMenu);
            

        }

        private void  menuNormal()
        {
            MenuItem reportesMenu = new MenuItem();
            reportesMenu.Header = "Reportes";
            MenuItem reporteAmbulanciaMenu = new MenuItem();
            reporteAmbulanciaMenu.Header = "Ingresar Reporte de Ambulancias";
            reporteAmbulanciaMenu.Click += mostrarIngresoDeReporte_Click;
            MenuItem generarReproteMenu = new MenuItem();
            generarReproteMenu.Header = "Generar Reporte de Incidentes";
            reportesMenu.Items.Add(reporteAmbulanciaMenu);
            reportesMenu.Items.Add(generarReproteMenu);
            this.menu.Items.Add(reportesMenu);
        }
        private void mostrarIngresoDeReporte_Click(object sender, RoutedEventArgs e)
        {
            if(this.contenido.Children.Count > 0)
            {
               var a=  MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    mostrarReporte();
                }
            }
            else
            {
                mostrarReporte();
            }
        }

        private void mostrarReporte()
        {
            MenuItem editarMenu = new MenuItem();
            editarMenu.Header="editar";
            MenuItem limpiarMenu = new MenuItem();
            limpiarMenu.Header = "limpiar";
            editarMenu.Items.Add(limpiarMenu);
            this.menu.Items.Add(editarMenu);
            this.contenido.Children.Clear();
            var contenido = new IngresoDeIncidente()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            this.contenido.Children.Add(contenido);
        }
    }
}
