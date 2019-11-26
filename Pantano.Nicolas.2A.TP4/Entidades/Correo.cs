using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
 
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Agrega un pauete al correo si no lo contiene ya
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns>retorna el correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool loContiene = false;
            foreach (Paquete a in c.Paquetes)
            {
                if (a == p)
                {
                    loContiene = true;
                }
            }
            if(loContiene==false)
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
                return c;
            }
            else
            {
                throw new TrackingIdRepetidoException("El tracking ID "+p.TrackingID + " ya figura en la lista de envios");
            }            

            
        }

        /// <summary>
        /// Retorna los datos de una lista de paquetes
        /// </summary>
        /// <param name="elementos">Lista de paquetes</param>
        /// <returns>Retorna los datos</returns>
        public string MostrarDatos(IMostrar <List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID,p.DireccionEntrega, p.Estado.ToString()));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Termina todos los hilos en ejecucion
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread a in this.mockPaquetes)
            {                
                a.Abort();
            }
        }

    }
}
