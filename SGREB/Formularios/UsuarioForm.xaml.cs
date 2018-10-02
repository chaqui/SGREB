using SGREB.Controlador;
using SGREB.miscellany;
using SGREB.Models;
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
    /// Lógica de interacción para UsuarioForm.xaml
    /// </summary>
    public partial class UsuarioForm : Window
    {
        private List<BomberoComboBox> bomberosList;
        private string[] tipos;
        private int tipoF;
        public UsuarioForm()
        {
            tipoF = 1;
            InitializeComponent();
            bomberosList = new List<BomberoComboBox>();
            obtenerBomberos();
            obtenerTipos();
            
        }

        public UsuarioForm(string nickName)
        {
            tipoF = 2;
            InitializeComponent();
            bomberosList = new List<BomberoComboBox>();
            obtenerBomberos();
            obtenerTipos();
            rellenarCampos(nickName);
        }

        private void rellenarCampos(string nickname)
        {
            Usuario usuario = new Usuario();
            var u = usuario.obtener(nickname);
            Controlador.Bombero bombero = new Controlador.Bombero();
            var b = bombero.Obtener(u.bombero);
            Persona persona = new Persona();
            var p = persona.obtener(b.persona);
            var n = p.nombres + " " + p.apellidos;
            cmbBombero.SelectedValue = n;
            cmbBombero.IsEnabled = false;
            txNickName.Text = nickname;
            txNickName.IsEnabled = false;
            txContrasenia.Text = u.contrasenia;
            cmbTipo.SelectedItem = u.rol;
        }

        private void obtenerBomberos()
        {
            Controlador.Bombero bombero = new Controlador.Bombero();
            var bomberos = bombero.obtenerVarios();
            foreach(var b in bomberos)
            {
                Persona persona = new Persona();
                var p = persona.obtener(b.persona);
                var nombre = p.nombres + " " + p.apellidos;
                bomberosList.Add(new BomberoComboBox {nombre= nombre, id=b.idBombero });
                
            }

            foreach(var b in bomberosList)
            {
                cmbBombero.Items.Add(b.nombre);
            }
        }

        private void obtenerTipos()
        {
            Usuario usuario = new Usuario();
            tipos = usuario.roles;
            foreach(var t in tipos)
            {
                cmbTipo.Items.Add(t);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txNickName.Text =="" && txContrasenia.Text == "")
            {
                MessageBox.Show("Falta ingresar información");
                return;
            }
            var id = obtenerIdBombero(cmbBombero.SelectedItem.ToString());
            if(id == "")
            {
                MessageBox.Show("No a seleccionado ningun bombero");
                return;
            }
            var tipo = cmbTipo.SelectedItem.ToString();
            if(tipo == "")
            {
                MessageBox.Show("No se a seleccionado el tipo de usuario");
            }
            TC_Usuario tcUsuario = new TC_Usuario { bombero = id, nickname = txNickName.Text, contrasenia = txContrasenia.Text, rol = tipo };
            MessageBox.Show(tipo);

            Usuario usuario = new Usuario();
            if (tipoF == 1) { 
            usuario.crear(tcUsuario);
            }
            else
            {
                usuario.modificar(tcUsuario);
            }
        }

        private string obtenerIdBombero(string nombre)
        {
            foreach(var b in bomberosList)
            {
                if(b.nombre == nombre)
                {
                    return b.id;
                }
            }
            return "";
        }
    }
}
