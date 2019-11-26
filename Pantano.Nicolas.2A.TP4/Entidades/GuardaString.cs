using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda el string en el archivo
        /// </summary>
        /// <param name="texto">String a ser guardado</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>Retorna true si lo pudo guardar</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true);
                writer.Write(texto);
                writer.Close();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
