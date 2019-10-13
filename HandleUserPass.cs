﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePass
{
    class HandleUserPass
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public HandleUserPass() { }
        /// <summary>
        /// Genera una lista con todos los usuarios y contraseñas
        /// </summary>
        /// <returns>Lista de tipo string</returns>
        public List<String> GetDataPassAndUser()
        {
            List<String> data = new List<string>();

            return data;
        }
        /// <summary>
        /// Agregar Usuario y contraseña
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool AddUserPass(string user, string pass)
        {
            return true;
        }
        /// <summary>
        /// Actualizar usuario y contraseña
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateUserPass(int id)
        {
            return true;
        }
        /// <summary>
        /// Borrar un usuario y contraseña
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUserPass(int id)
        {
            return true;
        }
    }
}