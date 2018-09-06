
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{
    public class Usuario : Bombero {

        public Usuario() {
        }

        public string nickname;

        public string contrasenia;


        /// <summary>
        /// @param Solicitud
        /// </summary>
        public void crearSolicitud(Solicitud solicitud, int tipoSolicitud, Boolean cbm) {
            // TODO implement here
            if (cbm)
            {

            }
        }

    } }