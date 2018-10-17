﻿using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.Controlador
{
    class CausaEnfermedadComun
    {
        public CausaEnfermedadComun()
        {

        }

        /// <summary>
        /// crear una causa de enfemedad
        /// </summary>
        /// <param name="comun"></param>
        /// <returns>id de la causa comun creada </returns>
        public int crear(TV_CausaEnfermedadComun comun)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_CausaEnfermedadComun.Add(comun);
            bitacora.SaveChanges();
            return comun.idCausa;
        }

        /// <summary>
        /// obtene todas las causas de enfermedda comin
        /// </summary>
        /// <returns></returns>
        public List<TV_CausaEnfermedadComun> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var comunes = bitacora.TV_CausaEnfermedadComun;
            return comunes.ToList();

        }
    }
}