using SGREB.Controlador;
using SGREB.Models;
using System.Collections.Generic;
using System.Windows;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para Bombero.xaml
    /// </summary>
    public partial class Bombero : Window
    {

        List<TV_Rol> roles;
        List<TV_Grado> grados;
        /// <summary>
        /// el tipo es 1 entonces es para crear, 
        /// si es 2 es para modificar. 
        /// </summary>
        private int tipo;
        private string id;
        private int idPersona; 

        /// <summary>
        /// construtor para la creación de un nuevo bombero
        /// </summary>
        public Bombero()
        {
            tipo = 1;
            InitializeComponent();
            obtenerGrados();
            obtenerRoles();

        }

        /// <summary>
        /// constructo para la modificacion de un bombero
        /// </summary>
        /// <param name="id"> id del bombero a modificar</param>
        public Bombero(string id)
        {
            MessageBox.Show(id);
            tipo = 2;
            this.id = id;
            InitializeComponent();
            obtenerGrados();
            obtenerRoles();
            obtenerCampos();
          
        }

        /// <summary>
        /// obtener todos los elemtos del bombero pra actualizarlo
        /// </summary>
        private void obtenerCampos()
        {
            Controlador.Bombero bombero = new Controlador.Bombero();
            var bom = bombero.Obtener(id);
            Persona persona = new Persona();
            idPersona = bom.persona;
            var per = persona.obtener(bom.persona);
            txCodigo.Text = bom.idBombero;
            txApellidos.Text = per.apellidos;
            txNombres.Text = per.nombres;
            txDPI.Text = per.dpi;
            var rol = new Controlador.Rol();
            var grado = new Controlador.Grado();
            var r = rol.obtener(bom.rol);
            var g = grado.obtener(bom.grado);
            cmbGrado.SelectedValue = g.nombreGrado;
            CmbRol.SelectedValue = r.nombre;
        }
          
        /// <summary>
        /// obtener todos los roles de la base de datos para 
        /// almacenarlos en el combo box
        /// </summary>
           private void obtenerRoles()
        {
            if(CmbRol.Items.Count > 0) { 
            this.CmbRol.Items.Clear();
            }
            Controlador.Rol rol = new Controlador.Rol();
            roles = rol.obtenerVarios();
            foreach (TV_Rol rolP in roles)
            {
                CmbRol.Items.Add(rolP.nombre);
            }

            CmbRol.Items.Add("crear un nuevo Rol...");

        }

        /// <summary>
        /// obtener el id del Grado seleccionado
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private int obtenerIdGrados(string nombre)
        {
           foreach( TV_Grado g in grados)
            {
                if(g.nombreGrado == nombre)
                {
                    return g.idGrado;
                }
            }
            return 0;
        }

        /// <summary>
        ///  obtener el id del rol seleccionado
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private int obtenerIdRol(string nombre)
        {
            foreach (TV_Rol r in roles)
            {
                if (r.nombre == nombre)
                {
                    return r.idRol;
                }
            }
            return 0;
        }

        /// <summary>
        /// obtener los grados y cargarlos en el comboBox
        /// </summary>
        private void obtenerGrados()
        {
            if(cmbGrado.Items.Count >0)
            {
                this.cmbGrado.Items.Clear();
            }

            Grado grado = new Grado();
            grados = grado.obtenerVarios();
            foreach (TV_Grado gradoP in grados)
            {
                cmbGrado.Items.Add(gradoP.nombreGrado);
            }
            cmbGrado.Items.Add("crear un nuevo Grado...");
        }

        /// <summary>
        /// evento que ocurre al cambiar la seleccion de Grado
        /// TODO:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGrado_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
            if (cmbGrado.SelectedItem.ToString() == "crear un nuevo Grado...")
            {
                var grado = new GradoForm();
                grado.ShowDialog();
                if (!IsInitialized)
                {
                    InitializeComponent();
                }
                obtenerGrados();
                return;
            }
        }

        /// <summary>
        /// evento que ocurre al cambiar la seleccion de combo box rol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbRol_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(CmbRol.SelectedItem.ToString() == "crear un nuevo Rol...")
            {
                var rol = new Rol();
                rol.ShowDialog();
                obtenerRoles();
            }
        }

        /// <summary>
        /// evento cuando se le da click al boton cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// evento cuando se le da click a guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(tipo ==1 )
            {
                crear();
            }
            else if(tipo == 2)
            {
                actualizar();
            }
            this.Close();
        }

        private void crear()
        {
            /// verificacion si se ingreso un nombre y un apellido
            if (txNombres.Text != "" && txApellidos.Text != "" && txCodigo.Text != "")
            {
                int idRol = obtenerIdRol(CmbRol.SelectedItem.ToString());
                ///verificar si selecciono un Rol
                if (idRol == 0)
                {
                    MessageBox.Show("No ha seleccionado el ROl", "error");
                    return;
                }

                int idGrado = obtenerIdGrados(cmbGrado.SelectedItem.ToString());

                /// verificar si se selecciono un grado
                if (idGrado == 0)
                {
                    MessageBox.Show("No ha seleccionado el Grado", "error");
                    return;
                }
                if (txDPI.Text.Length != 13)
                {
                    MessageBox.Show("error al ingresar DPI");
                    return;
                }

                //Se guarda a la persona
                TC_Persona tcPersona = new TC_Persona();
                tcPersona.nombres = txNombres.Text;
                tcPersona.apellidos = txApellidos.Text;
                tcPersona.dpi = txDPI.Text;
                Persona persona = new Persona();
                int idPersona = persona.Crear(tcPersona);
                //se guarda al bombero
                TC_Bombero tC_Bombero = new TC_Bombero();
                tC_Bombero.idBombero = txCodigo.Text;
                tC_Bombero.persona = idPersona;
                tC_Bombero.rol = idRol;
                tC_Bombero.grado = idGrado;
                Controlador.Bombero bomb = new Controlador.Bombero();
                bomb.Crear(tC_Bombero);
                MessageBox.Show("Elemento Creado");
            }
            else
            {
                MessageBox.Show("Le falto el nombre o el apellido", "Error");
            }
        }

        private void actualizar()
        {
            //actualizar Bombero 
            int idGrado = obtenerIdGrados(cmbGrado.SelectedItem.ToString());
            int idRol = obtenerIdRol(CmbRol.SelectedItem.ToString());
            TC_Bombero tC_Bombero = new TC_Bombero();
            tC_Bombero.idBombero = txCodigo.Text;
            tC_Bombero.persona = idPersona;
            tC_Bombero.rol = idRol;
            tC_Bombero.grado = idGrado;
            Controlador.Bombero bomb = new Controlador.Bombero();
            bomb.modificar(tC_Bombero);

            //actualizar Persona
            TC_Persona tcPersona = new TC_Persona();
            tcPersona.idPersona = idPersona;
            tcPersona.nombres = txNombres.Text;
            tcPersona.apellidos = txApellidos.Text;
            tcPersona.dpi = txDPI.Text;
            Persona persona = new Persona();
            persona.modificar(tcPersona);
            MessageBox.Show("Elemento Actualizado");
        }
        
    }
}
