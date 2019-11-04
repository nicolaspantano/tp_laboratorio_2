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
    {
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
