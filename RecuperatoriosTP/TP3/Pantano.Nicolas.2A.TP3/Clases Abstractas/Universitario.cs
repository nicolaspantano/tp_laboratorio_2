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
            this.legajo = -1;
        }
        
        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Compara que ambos objetos sean del mismo tipo
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>True si son del mismo tipo</returns>
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compara dos universitarios
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Si son iguales, retorna true</returns>
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

        /// <summary>
        /// Compara dos universitarios
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Si son distintos retorna true</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Da una descripcion del universitario
        /// </summary>
        /// <returns>Retorna la descripcion en forma de string</returns>
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
