using SGREB.Controlador;
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
    /// Lógica de interacción para CausaSuicidioForm.xaml
    /// </summary>
    public partial class AnimalForm : Window
    {
        private int forma;
        private int idAnimal;
        public AnimalForm(  int idAnimal)
        {
            this.forma = 2;
            InitializeComponent();
            this.idAnimal = idAnimal;
            Animal animal = new Animal();
            txNombreCausa.Text = animal.obtener(idAnimal).tipo;
        }
        public AnimalForm()
        {
            this.forma = 1;
            InitializeComponent();


        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            string nombre = txNombreCausa.Text;

            if(nombre == "")
            {
                MessageBox.Show("no ha ingresado ningun nombre");
                return;
            }
            TV_Animal tvanimal = new TV_Animal { tipo = nombre };
            Animal animal = new Animal();
            if (forma == 1)
            {
                animal.crear(tvanimal);
                this.Close();
            }
            else
            {
                tvanimal.idAnimal = this.idAnimal;
                animal.modificar(tvanimal);
                this.Close();
            }
           
        }
    }
}
