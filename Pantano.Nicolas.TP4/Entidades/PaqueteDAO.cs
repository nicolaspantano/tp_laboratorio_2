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

        static PaqueteDAO()
        {
            try
            {
                PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
                PaqueteDAO.comando = new SqlCommand();
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
                PaqueteDAO.comando.CommandType = CommandType.Text;

            }
            catch (Exception e)
            {
                throw e;
            }
            

        }

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
            catch(Exception e)
            {
                throw e;
            }
        }



    }
}
