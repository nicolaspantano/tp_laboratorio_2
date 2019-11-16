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
        public static bool Guardar(this string texto,string archivo)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Environment.SpecialFolder.Desktop + archivo);
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
