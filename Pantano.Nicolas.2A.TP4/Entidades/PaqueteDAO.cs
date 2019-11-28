using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Conecta la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            try
            {
                PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
                PaqueteDAO.comando = new SqlCommand();
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
                PaqueteDAO.comando.CommandType = CommandType.Text;

            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al conectar con la base de datos");
            }
            

        }

        /// <summary>
        /// Inserta el paquete en la base de datos
        /// </summary>
        /// <param name="p">Paquete</param>
        /// <returns>Retorna true si lo pudo insertar</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.CommandText = "INSERT INTO [correo-sp-2017].dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Pantano Nicolas')";
                PaqueteDAO.comando.ExecuteNonQuery();
                PaqueteDAO.conexion.Close();
                return true;
            }
            catch(Exception)
            {
                throw new Exception("Ocurrio un error al insertar el paquete en la base de datos");
            }
        }



    }
}
