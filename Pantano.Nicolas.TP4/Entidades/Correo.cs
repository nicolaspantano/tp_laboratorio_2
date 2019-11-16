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

        public static Correo operator +(Correo c, Paquete p)
        {
            if (!(c.Paquetes.Contains(p)))
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
                return c;
            }
            else
            {
                throw new TrackingIdRepetidoException("Ocurrio un error al agregar el paquete al correo");
            }            

            
        }

        public string MostrarDatos(IMostrar <List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete a in ((Correo)elementos).Paquetes)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }

        public void FinEntregas()
        {
            foreach(Thread a in this.mockPaquetes)
            {                
                a.Abort();
            }
        }

    }
}
