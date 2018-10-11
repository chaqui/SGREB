
using SGREB.Models;
using System.Collections.Generic;
using System.Linq;

namespace SGREB.Controlador
{
    /// <summary>
    /// clase para administrar la tabla de usuarios
    /// </summary>
    public class Usuario  {
        public string[] roles;
        /// <summary>
        /// obtner los usuarios
        /// </summary>
        public Usuario() {
            roles = new string[2];
            roles[0] = "usuario";
            roles[1] = "admin";
        }
        
        /// <summary>
        /// crear usuario 
        /// </summary>
        /// <param name="tcUsuariio">usuario a modificar</param>
        public void crear(TC_Usuario tcUsuariio)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Usuario.Add(tcUsuariio);
            bitacora.SaveChanges();
        }

        /// <summary>
        /// modificar usuario
        /// </summary>
        /// <param name="tcUsuario">usuario a modificar</param>
        /// TODO:
        public void modificar(TC_Usuario tcUsuario)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcUsuarioM = bitacora.TC_Usuario.Find(tcUsuario.nickname);
                tcUsuarioM.contrasenia = tcUsuario.contrasenia;
                tcUsuarioM.rol = tcUsuario.rol;
                tcUsuarioM.bombero = tcUsuario.bombero;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        public List<TC_Usuario> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var usuarios = bitacora.TC_Usuario;
            return usuarios.ToList();
        }

        /// <summary>
        /// obtener al suario por su mickname
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public TC_Usuario obtener(string nickname)
        {
            var bitacora = new bitacoraBomberoaContext();
            var usuario = bitacora.TC_Usuario.Where((s) => s.nickname == nickname).Single();
            return usuario;
        }
    }
}