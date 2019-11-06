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
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

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
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());            
            sb.Append("ESTADOD DE CUENTA: ");
            sb.AppendLine(this.estadoCuenta.ToString());
            sb.Append("TOMA CLASES DE: ");
            sb.AppendLine(this.claseQueToma.ToString());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this.claseQueToma.ToString();
        }
#endregion
    }
}
