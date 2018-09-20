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
    /// Lógica de interacción para UsuarioControl.xaml
    /// </summary>
    public partial class UsuarioControl : UserControl
    {
        public UsuarioControl()
        {
            InitializeComponent();
            obtenerUsuarios();

        }

        public void obtenerUsuarios()
        {
            if(dataGridUsuarios.Items.Count > 0)
            {
                dataGridUsuarios.Items.Clear();
            }
            Usuario usuario = new Usuario();
            var usuarios = usuario.obtenerVarios();
            if(usuarios.Count > 0)
            {
                foreach (var u in usuarios)
                {
                    var ud = new UsuarioDataGrid { rol = u.rol, nickName = u.nickname };
                    dataGridUsuarios.Items.Add(ud);

                }
            }
            else
            {
                var ud = new UsuarioDataGrid { nickName = "no existe ningun usuario" };
                dataGridUsuarios.Items.Add(ud);
            }

        }

        private void btAgregarElemento_Click(object sender, RoutedEventArgs e)
        {
            UsuarioForm uf = new UsuarioForm();
            uf.ShowDialog();
            obtenerUsuarios();
        }

        private void btModificarElemento_Click(object sender, RoutedEventArgs e)
        {
            var seleccionado = (UsuarioDataGrid)dataGridUsuarios.SelectedItem;
            UsuarioForm usuarioForm = new UsuarioForm(seleccionado.nickName);
            usuarioForm.ShowDialog();
            obtenerUsuarios();
        }
    }
}
