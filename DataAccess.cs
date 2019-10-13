using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SavePass
{
    class DataAccess
    {
        private byte[] Clave = Encoding.ASCII.GetBytes("wVEW!ju3");
        private byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
        const string PATH = @".\data.txt";
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DataAccess()
        {
            if(!File.Exists(PATH))
            {
                FileStream fs = File.Create(PATH);
                fs.Close();
            }
        }
        /// <summary>
        /// Leer los datos de un documento
        /// </summary>
        /// <returns>Lista de datos del documento</returns>
        public List<String> ReadFile()
        {
            List<String> list = new List<string>();

            using(StreamReader sr = File.OpenText(PATH))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(GetDeCipherText(line));
                }
            }

            return list;
        }
        /// <summary>
        /// Escribir los datos ee documento
        /// </summary>
        /// <returns>Lista de datos del documento</returns>
        public bool WriteFile(List<String> list)
        {
            foreach(string line in list)
            {
                File.AppendAllLines(PATH, new String[] { GetCipherText(line) });
            }
            return true;
        }
        /// <summary>
        /// Actualziar los datos en documento
        /// </summary>
        /// <returns>Lista de datos del documento</returns>
        public bool UpdateFile(List<String> list)
        {
            return true;
        }
        /// <summary>
        /// Borrar los datos en documento
        /// </summary>
        /// <returns>Lista de datos del documento</returns>
        public bool DeleteFile(List<String> list)
        {
            List<string> data = ReadFile();
            List<string> lstAux = ReadFile();

            foreach(string user in list)
            {
                foreach (string line in data)
                {
                    if (line.Split(';')[0] == user)
                    {
                        lstAux.Remove(line);
                    }
                }
            }

            File.WriteAllText(PATH, "");

            return WriteFile(lstAux);
        }
        /// <summary>
        /// Permite cifrar el mensaje
        /// </summary>
        /// <param name="text">Mensaje a cifrar</param>
        /// <returns>Mensaje cifrado</returns>
        private string GetCipherText(string text)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(text);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);
        }
        /// <summary>
        /// Permite descifrar un mensaje
        /// </summary>
        /// <param name="text">Mensaje a descifrar</param>
        /// <returns>Mensaje descifrado</returns>
        private string GetDeCipherText(string text)
        {
            byte[] inputBytes = Convert.FromBase64String(text);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;
        }
    }
}
