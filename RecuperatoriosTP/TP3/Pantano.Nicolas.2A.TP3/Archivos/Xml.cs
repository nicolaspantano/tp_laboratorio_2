using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {/// <summary>
    /// Guarda informacion en un archivo .xml
    /// </summary>
    /// <param name="archivo">Ruta del archivo</param>
    /// <param name="datos">Informacion</param>
    /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(archivo, true);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                writer.Close();
                return true;
            }
            catch (ArchivosException e)
            {
                throw e.InnerException;

            }
        }

        /// <summary>
        /// Lee un archivo .xml
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Parametro de salida</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (ArchivosException e)
            {
                throw e.InnerException;
            }
        }
    }
}
