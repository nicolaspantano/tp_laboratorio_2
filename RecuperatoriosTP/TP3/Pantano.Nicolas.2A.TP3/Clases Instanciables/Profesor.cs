using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor()
            :this(-1,"SinNombre","Sin Apellido","",ENacionalidad.Argentino)
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();

        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Comprueba si el profesor da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna true si la da</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if(!(i is null))
            {
                foreach (Universidad.EClases actual in i.clasesDelDia)
                {
                    if (actual == clase)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// Comprueba si el profesor no da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna true si no la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Asigna al profesor dos clases aleatorias
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));   
            
        }

        /// <summary>
        /// Da informacion de las clases del dia
        /// </summary>
        /// <returns>Retorna la informacion</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            
            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Da informacion del profesor
        /// </summary>
        /// <returns>Retorna la informacion</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Da informacion del profesor
        /// </summary>
        /// <returns>Retorna la informacion</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
#endregion
    }
}
