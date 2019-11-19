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

        public static bool operator !=(Paquete p1,Paquete p2)
        {
            return !(p1 == p2);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);          
            
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

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
