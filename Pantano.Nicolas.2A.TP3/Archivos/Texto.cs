using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto 
    {
        /// <summary>
        /// Guarda infomracion en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Informacion</param>
        /// <returns>Retorna true si lo pudo guardar</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(archivo,true);
                writer.Write(datos);
                writer.Close();
                return true;
            }
            catch(ArchivosException e)
            {
                throw e.InnerException;                
            }
            
        }
        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Parametro de salida</param>
        /// <returns>Retorna true si lo pudo leer</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                reader.Close();
                return true;
            }
            catch(ArchivosException e)
            {
                throw e.InnerException;
            }
        }
    }
}
