using SGREB.Paginas;
using SGREB.Paginas.administrador;
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
        private Boolean reporteAdministrador;
        private Boolean administrador;
        public MainWindow() 
        {
            menuInicial();
        }

        private void menuInicial()
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
                    administrador = false;
                    menuNormal();
                }
                else
                {
                    administrador = true;
                    menuAdministrador(); }
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
            usuariosMenu.Click += usuarios_click;
            usuariosMenu.Header = "usuarios";
            administrarMenu.Items.Add(usuariosMenu);

            MenuItem bomberosMenu = new MenuItem();
            bomberosMenu.Click += bomberos_click;
            bomberosMenu.Header = "Bomberos";
            administrarMenu.Items.Add(bomberosMenu);

            MenuItem unidadesMenu = new MenuItem();
            unidadesMenu.Header = "Unidades";
            unidadesMenu.Click += unidades_click;
            administrarMenu.Items.Add(unidadesMenu);
            this.menu.Items.Add(administrarMenu);

        }


        private void  menuNormal()
        {
            MenuItem reportesMenu = new MenuItem();
            reportesMenu.Header = "Reportes";
            MenuItem reporteAmbulanciaMenu = new MenuItem();
            reporteAmbulanciaMenu.Header = "Ingresar Reporte de Ambulancias";
            reporteAmbulanciaMenu.Click += mostrarIngresoDeReporte_Click;
            MenuItem generarReproteMenu = new MenuItem();
            generarReproteMenu.Header = "Generar Reportes";
            MenuItem multiReporteMenu = new MenuItem();
            multiReporteMenu.Header = "Reporte de Incidentes";

            generarReproteMenu.Items.Add(multiReporteMenu);
            MenuItem reporteResumenMenu = new MenuItem();
            reporteResumenMenu.Header = "Reporte Resunmido";

            generarReproteMenu.Items.Add(reporteResumenMenu);
            MenuItem reporteEspecial = new MenuItem();
            reporteEspecial.Header = "Reporte Especial";

            generarReproteMenu.Items.Add(reporteEspecial);

            reportesMenu.Items.Add(reporteAmbulanciaMenu);
            reportesMenu.Items.Add(generarReproteMenu);
            

            this.menu.Items.Add(reportesMenu);

            MenuItem sesion = new MenuItem();
            sesion.Header = "Sesión";
            MenuItem cerrarSesion = new MenuItem();
            cerrarSesion.Header = "cerrar Sesion";
            cerrarSesion.Click += cerrarSesio_click;
            sesion.Items.Add(cerrarSesion);
            this.menu.Items.Add(sesion);

        }
        private void cerrarSesio_click(object sebder, RoutedEventArgs e)
        {
            var a = MessageBox.Show("Desea cerrar sesión", "Alerta", MessageBoxButton.OKCancel);
            if(a == MessageBoxResult.OK)
            {
                this.contenido.Children.Clear();
                this.menu.Items.Clear();
                menuInicial();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sebder"></param>
        /// <param name="e"></param>

        private void reportes_click(object sebder, RoutedEventArgs e)
        {
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);

                if (a == MessageBoxResult.OK)
                {
                    if (reporteAdministrador)
                    {
                        this.menu.Items.Clear();
                        menuAdministrador();
                    }
                    this.contenido.Children.Clear();
                    var reportes = new GenerarReportes()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(reportes);
                }
            }
            else
            {
                this.contenido.Children.Clear();
                var reportes = new GenerarReportes()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(reportes);
            }

        }

        private void resumen_click(object sebder, RoutedEventArgs e)
        {
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);

                if (a == MessageBoxResult.OK)
                {
                    if (reporteAdministrador)
                    {
                        this.menu.Items.Clear();
                        menuAdministrador();
                    }
                    this.contenido.Children.Clear();
                    var reportes = new ResumenReporte()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(reportes);
                }
            }
            else
            {
                this.contenido.Children.Clear();
                var reportes = new ResumenReporte()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(reportes);
            }
        }

        private void especial_click(object sebder, RoutedEventArgs e)
        {
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);

                if (a == MessageBoxResult.OK)
                {
                    if (reporteAdministrador)
                    {
                        this.menu.Items.Clear();
                        menuAdministrador();
                    }
                    this.contenido.Children.Clear();
                    var reportes = new ReporteEspecial()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(reportes);
                }
            }
            else
            {
                this.contenido.Children.Clear();
                var reportes = new ReporteEspecial()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(reportes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sebder"></param>
        /// <param name="e"></param>

        private void usuarios_click(object sebder, RoutedEventArgs e)
        {
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);

                if(a == MessageBoxResult.OK)
                {
                    if (reporteAdministrador)
                    {
                        this.menu.Items.Clear();
                        menuAdministrador();
                    }
                    this.contenido.Children.Clear();
                    var usuarios = new UsuarioControl()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(usuarios);
                }
            }
            else
            {
                this.contenido.Children.Clear();
                var usuarios = new UsuarioControl()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(usuarios);
            }


        }

        private void bomberos_click(object sebder, RoutedEventArgs e)
        {
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    if (reporteAdministrador)
                    {
                        this.menu.Items.Clear();
                        menuAdministrador();
                    }
                    this.contenido.Children.Clear();
                    var bomberos = new Bomberos()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(bomberos);
                }
            }
            else
            {
                this.contenido.Children.Clear();
                var bomberos = new Bomberos()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(bomberos);
            }
        }
        private void unidades_click(object sebder, RoutedEventArgs e)
        {
            if(this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    if (reporteAdministrador)
                    {
                        this.menu.Items.Clear();
                        menuAdministrador();
                    }
                    this.contenido.Children.Clear();
                    var unidades = new UnidadesControl()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(unidades);
                }
            }
            else
            {
                this.contenido.Children.Clear();
                var unidades = new UnidadesControl()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(unidades);
            }
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
            if (administrador)
            {
                reporteAdministrador = true;
            }
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
