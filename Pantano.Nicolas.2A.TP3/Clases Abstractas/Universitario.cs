using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributo
        private int legajo;
        #endregion

        #region Constructores
        public Universitario()
            :base()
        {
            //this.legajo = -1;
        }
        
        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Sobrecargas
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2))
            {
                if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                {
                    return true;
                }
            }
            
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Metodos
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append("LEGAJO NUMERO: ");
            sb.AppendLine(this.legajo.ToString());

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
        #endregion
    }
}
