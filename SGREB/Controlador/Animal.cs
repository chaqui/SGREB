
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{


public class Animal  {

    public Animal() {
    }
        private int idAnimal { set; get; };
        private string nombre { set; get; }
        public Animal(int idAnimal, string nombre)
        {
            this.idAnimal = idAnimal;
            this.nombre = nombre;
        }

        public Animal(string nombre)
        {
            this.nombre = nombre;
        }

        public List<TV_Animal> obtenerTodos() {
            var bitacora = new bitacoraBomberoaContext();
            var tvAnimales = bitacora.TV_Animal;
            return tvAnimales.ToList();
        }

        public void crear()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvAnimal = new TV_Animal();
            tvAnimal.tipo = this.nombre;
            bitacora.TV_Animal.Add(tvAnimal);
            bitacora.SaveChanges();
        }
        public TV_Animal obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvAnimales = bitacora.TV_Animal.Where(s => s.idAnimal == id).Single();
            return tvAnimales;
        }

        public void modificar(Animal animal)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvAnimal = bitacora.TV_Animal.Find(animal.idAnimal);
                tvAnimal.tipo = animal.nombre;
                bitacora.SaveChanges();
            }
        }




   
}
}