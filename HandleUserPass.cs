using System;
using System.Collections.Generic;
namespace SavePass
{
    class HandleUserPass : DataAccess
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
            List<String> data = ReadFile();

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
            List<String> list = new List<String>();

            list.Add(user + ";" + pass);

            return WriteFile(list);
        }
        /// <summary>
        /// Actualizar usuario y contraseña
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateUserPass(string user, string pass)
        {
            List<string> data = new List<string>();

            data.Add(user + ";" + pass);
            return UpdateFile(data);
        }
        /// <summary>
        /// Borrar un usuario y contraseña
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUserPass(string user)
        {
            List<String> list = new List<String>();

            list.Add(user);

            return DeleteFile(list);
        }
    }
}
