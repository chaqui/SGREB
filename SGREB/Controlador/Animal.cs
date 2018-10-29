
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{

/// <summary>
/// clase que define las funciones para almacenar los animales 
/// que han mordido a un paciente
/// </summary>
public class Animal  {

        /// <summary>
        /// constructor para uso de la funcionalidad
        /// </summary>
        public Animal() {
        }
        private int idAnimal { set; get; }
        private string nombre { set; get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int crear(TV_Animal animal)
        {
                var bitacora = new bitacoraBomberoaContext();
                bitacora.TV_Animal.Add(animal);
                bitacora.SaveChanges();
                return animal.idAnimal;
            }

        /// <summary>
        /// obtiene un animalñ por el id en la base de datos
        /// </summary>
        /// <param name="id">id del animal a buscar</param>
        /// <returns>el animal encontrado, si no hay animal retorna nulll</returns>
        public TV_Animal obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvAnimales = bitacora.TV_Animal.Where(s => s.idAnimal == id).Single();
            return tvAnimales;
        }

        /// <summary>
        /// modificar animal en la base de datos
        /// </summary>
        /// <param name="animal">anuimal a modificar</param>
        public void modificar(TV_Animal animal)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvAnimal = bitacora.TV_Animal.Find(animal.idAnimal);
                tvAnimal.tipo = animal.tipo;
                bitacora.SaveChanges();
            }
        }


       public List<TV_Animal> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var animales = bitacora.TV_Animal;
            return animales.ToList();

        }


        public void eliminar(int id)
        {
            var seleccionado = obtener(id);
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            context.TV_Animal.Remove(seleccionado);
            context.SaveChanges();
        }

    }
}