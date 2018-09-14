
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
    /// constructor para la selección y la actualización
    /// </summary>
    /// <param name="idAnimal"></param>
    /// <param name="nombre"></param>
    public Animal(int idAnimal, string nombre):this(nombre)
    {
        this.idAnimal = idAnimal;
           
    }

    /// <summary>
    /// constructor para la creación
    /// </summary>
    /// <param name="nombre"></param>
    public Animal(string nombre)
    {
        this.nombre = nombre;
    }

    /// <summary>
    /// obterner todos los animales almacenados en la base de datos 
    /// </summary>
    /// <returns>retorna la lista de animales obtenida de la base de datos</returns>
    public List<TV_Animal> obtenerTodos() {
        var bitacora = new bitacoraBomberoaContext();
        var tvAnimales = bitacora.TV_Animal;
        return tvAnimales.ToList();
    }

    /// <summary>
    /// crear un animal en la base de datos
    /// </summary>
    public void crear()
    {
        var bitacora = new bitacoraBomberoaContext();
        var tvAnimal = new TV_Animal();
        tvAnimal.tipo = this.nombre;
        bitacora.TV_Animal.Add(tvAnimal);
        bitacora.SaveChanges();
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