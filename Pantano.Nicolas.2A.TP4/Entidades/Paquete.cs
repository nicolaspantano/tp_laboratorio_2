using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;

        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Dos paquetes seran iguales si tienen el mismo Tracing ID
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>Retorna true si son iguales</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (!(p1.Equals(null) && !(p2.Equals(null))))
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Dos paquetes seran distintos si tienen diferentes TrackingID
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>Retorna true si son distintos</returns>
        public static bool operator !=(Paquete p1,Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Retorna los datos de un paquete
        /// </summary>
        /// <param name="elemento">Paquete a mostrar</param>
        /// <returns>Retorna los datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);          
            
        }

        /// <summary>
        /// Retorna los datos de un paquete
        /// </summary>
        /// <returns>Retorna los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Cambia el estado del paquete a travez de hilos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(this, new EventArgs());
            }

            PaqueteDAO.Insertar(this);
            
        }


    }
}
