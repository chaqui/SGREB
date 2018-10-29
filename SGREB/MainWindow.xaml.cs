using SGREB.Paginas;
using SGREB.Paginas.administrador;
using System;
using System.Windows;
using System.Windows.Controls;

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


            MenuItem editarMenu = new MenuItem();
            editarMenu.Header = "Editar";

            MenuItem animalesMenu = new MenuItem();
            animalesMenu.Header = "Animales";
            animalesMenu.Click += animales_click;
            editarMenu.Items.Add(animalesMenu);

            MenuItem nfermedadComunMenu = new MenuItem();
            nfermedadComunMenu.Header = "Enfermedades Comunes";
            nfermedadComunMenu.Click += EnfermedadComun_click;
            editarMenu.Items.Add(nfermedadComunMenu);

            MenuItem IntoxicacionMenu = new MenuItem();
            IntoxicacionMenu.Header = "Causas de Intoxicación";
            IntoxicacionMenu.Click += intoxicacion_click;
            editarMenu.Items.Add(IntoxicacionMenu);


            MenuItem causaSuicidioMenu = new MenuItem();
            causaSuicidioMenu.Header = "Causas de Suicidio";
            causaSuicidioMenu.Click += suicidio_click;
            editarMenu.Items.Add(causaSuicidioMenu);

            MenuItem GradoMenu = new MenuItem();
            GradoMenu.Header = "Grados";
            GradoMenu.Click += grado_click;
            editarMenu.Items.Add(GradoMenu);

            MenuItem medioSolicitudoMenu = new MenuItem();
            medioSolicitudoMenu.Header = "Medio Solicitud";
            medioSolicitudoMenu.Click += medioSolicitudoMenu_click;
            editarMenu.Items.Add(medioSolicitudoMenu);

            MenuItem rolMenu = new MenuItem();
            rolMenu.Header = "Medio Solicitud";
            rolMenu.Click += rolMenu_click;
            editarMenu.Items.Add(rolMenu);

            MenuItem tipoServicioMenu = new MenuItem();
            tipoServicioMenu.Header = "Tipos de Servicio";
            tipoServicioMenu.Click += tipoServicioMenu_click;
            editarMenu.Items.Add(tipoServicioMenu);

            MenuItem tipoUnidadMenu = new MenuItem();
            tipoUnidadMenu.Header = "Tipos de Unidad";
            tipoUnidadMenu.Click += tipoUnidadMenu_click;
            editarMenu.Items.Add(tipoUnidadMenu);

            MenuItem tipoVehiculoMenu = new MenuItem();
            tipoVehiculoMenu.Header = "Tipos de Unidad";
            tipoVehiculoMenu.Click += tipoVehiculoMenu_click;
            tipoVehiculoMenu.Items.Add(tipoVehiculoMenu);

            this.menu.Items.Add(editarMenu);

        }

        private void tipoVehiculoMenu_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("tipoVehiculo")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("tipoVehiculo")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void tipoUnidadMenu_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("tipoUnidad")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("tipoUnidad")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void tipoServicioMenu_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("tipoServicio")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("tipoServicio")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void rolMenu_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("rol")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("rol")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void medioSolicitudoMenu_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("medioSolicitud")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("medioSolicitud")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void grado_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("grado")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("grado")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void suicidio_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("causaSuicidio")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("causaSuicidio")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void intoxicacion_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("causaIntoxicacion")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("causaIntoxicacion")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void EnfermedadComun_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("CausaEnfermedadComun")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("CausaEnfermedadComun")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void animales_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
            {
                var a = MessageBox.Show("Esta cambiando de formulario", "Alerta", MessageBoxButton.OKCancel);
                if(a == MessageBoxResult.OK)
                {
                    this.contenido.Children.Clear();
                    var certificacion = new EditarElementos("animal")
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }

            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new EditarElementos("animal")
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }
            private void  menuNormal()
        {
            MenuItem reportesMenu = new MenuItem();
            reportesMenu.Header = "Reportes";
            MenuItem reporteAmbulanciaMenu = new MenuItem();
            reporteAmbulanciaMenu.Header = "Ingresar Reporte de Ambulancias";
            reporteAmbulanciaMenu.Click += mostrarIngresoDeReporte_Click;
            MenuItem generarReproteMenu = new MenuItem();
            generarReproteMenu.Header = "Generar Informes";
            MenuItem multiReporteMenu = new MenuItem();
            multiReporteMenu.Header = "Informe de Incidentes";
            multiReporteMenu.Click += MultiReporteMenu_Click;
            generarReproteMenu.Items.Add(multiReporteMenu);
            MenuItem reporteResumenMenu = new MenuItem();
            reporteResumenMenu.Header = "Resumen Completo";
            reporteResumenMenu.Click += reportes_click;
            generarReproteMenu.Items.Add(reporteResumenMenu);
            if (administrador)
            {
                MenuItem reporteEspecial = new MenuItem();
                reporteEspecial.Header = "Certificacion de Reporte de Ambulancia";
                reporteEspecial.Click += certificacion_click;
                generarReproteMenu.Items.Add(reporteEspecial);
            }
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

        private void certificacion_click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
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
                    var certificacion = new Certificacion()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    this.contenido.Children.Add(certificacion);
                }
            }
            else
            {
                this.contenido.Children.Clear();
                var certificacion = new Certificacion()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(certificacion);
            }
        }

        private void MultiReporteMenu_Click(object sender, RoutedEventArgs e)
        {
            scrollBackground.Visibility = Visibility.Collapsed;
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
                    var reportes = new GenerarReporte1()
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
                var reportes = new GenerarReporte1()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                this.contenido.Children.Add(reportes);
            }
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
            scrollBackground.Visibility = Visibility.Collapsed;
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
            scrollBackground.Visibility = Visibility.Collapsed;
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
            scrollBackground.Visibility = Visibility.Collapsed;
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
                    var reportes = new Certificacion()
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
                var reportes = new Certificacion()
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
            scrollBackground.Visibility = Visibility.Collapsed;
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
            scrollBackground.Visibility = Visibility.Collapsed;
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
            scrollBackground.Visibility = Visibility.Collapsed;
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
            scrollBackground.Visibility = Visibility.Collapsed;
            if (this.contenido.Children.Count > 0)
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
            scrollBackground.Visibility = Visibility.Collapsed;
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
