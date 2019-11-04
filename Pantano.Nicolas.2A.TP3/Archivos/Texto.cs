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
