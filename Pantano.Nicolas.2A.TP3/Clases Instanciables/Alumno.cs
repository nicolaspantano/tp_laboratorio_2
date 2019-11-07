using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia,Deudor,Becado
        }
        #endregion

        #region Atributos
        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases claseQueToma;
        #endregion

        #region Constructores
        public Alumno()
            :base()
        {
            
        }

        public Alumno(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma,EEstadoCuenta.AlDia)
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.estadoCuenta = estadoCuenta;
            this.claseQueToma = claseQueToma;
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Comprueba si el alumno toma una clase dada
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase que deberia tomar</param>
        /// <returns>Retorna true si el alumno toma la clase</returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Comprueba si el alumno no toma una clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase que no deberia tomar</param>
        /// <returns>Retorna true si el alumno no toma la clase</returns>
        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Hace publicos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Da una descripcion del Alumno
        /// </summary>
        /// <returns>Retorna la descripcion en forma de string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());            
            sb.Append("ESTADOD DE CUENTA: ");
            sb.AppendLine(this.estadoCuenta.ToString());
            sb.Append("TOMA CLASES DE: ");
            sb.AppendLine(this.claseQueToma.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Indica que clase toma el alumno
        /// </summary>
        /// <returns>Retorna la informacion en forma de string</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this.claseQueToma.ToString();
        }
#endregion
    }
}
