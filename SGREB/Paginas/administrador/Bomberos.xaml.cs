using SGREB.Controlador;
using SGREB.miscellany;
using SGREB.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SGREB.Paginas.administrador
{
    /// <summary>
    /// Lógica de interacción para Bomberos.xaml
    /// </summary>
    public partial class Bomberos : UserControl
    {
        public Bomberos()
        {
            InitializeComponent();
            obtenerBomberos();

        }

        private void btAgregarElemento_Click(object sender, RoutedEventArgs e)
        {
            SGREB.Formularios.Bombero bombero = new Formularios.Bombero();
            bombero.ShowDialog();
        }

        private void obtenerBomberos()
        {
            if (dataGridBomberos.Items.Count > 0)
            {
                dataGridBomberos.Items.Clear();
            }
            Bombero bombero = new Bombero();
            List<TC_Bombero> bomberos = bombero.obtenerVarios();
            if(bomberos.Count != 0)
            {
                foreach(var bom in bomberos)
                {
                    Persona persona = new Persona();
                    var per = persona.obtener(bom.persona);
                    Grado grado = new Grado();
                    var g = grado.obtener(bom.grado);
                    Rol rol = new Rol();
                    var r = rol.obtener(bom.rol);
                    var elemento = new BomberoDataGrid { nombres = per.nombres, id = bom.idBombero, apellidos = per.apellidos, grado = g.nombreGrado, rol = r.nombre };
                    dataGridBomberos.Items.Add(elemento);
                }
            }
            else
            {
                var elemento = new BomberoDataGrid { nombres = "No existe ningun Bombero" };


            }
        }

        private void btModificarElemento_Click(object sender, RoutedEventArgs e)
        {
            var seleccionado = (BomberoDataGrid)dataGridBomberos.SelectedItem;
            SGREB.Formularios.Bombero bombero = new Formularios.Bombero(seleccionado.id);
            bombero.ShowDialog();
            obtenerBomberos();
        }
    } 
}
