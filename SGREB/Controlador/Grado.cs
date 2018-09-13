
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{ 

public class Grado : CRUD {

    public Grado() {
    }

    private int idGrado;

    private String nombreGrado;

        public Grado(int idGrado, string nombreGrado)
        {
            this.idGrado = idGrado;
            this.nombreGrado = nombreGrado;
        }

        public Grado(string nombreGrado)
        {
            this.nombreGrado = nombreGrado;
        }

        public void Crear()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvGrado = new TV_Grado();
            tvGrado.nombreGrado = this.nombreGrado;
            bitacora.TV_Grado.Add(tvGrado);
            bitacora.SaveChanges();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void modificar(int id)
        {
            throw new NotImplementedException();
        }

        public Grado obtener(int? id)
        {
            
            var bitacora = new bitacoraBomberoaContext();
            var grados = bitacora.TV_Grado.Where(s => s.idGrado == id);
            foreach(var grado in grados)
            {
                return new Grado(grado.idGrado, grado.nombreGrado);
            }
            return null;
        }

        public List<TV_Grado> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvGrados = bitacora.TV_Grado;
            return tvGrados.ToList();
        }

        public void obtener(int id)
        {
            throw new NotImplementedException();
        }

        List<object> CRUD.obtenerVarios()
        {
            throw new NotImplementedException();
        }
    }
}