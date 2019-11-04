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
            this._randomClases();
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }
        #endregion

        #region Sobrecarga de operadores
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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #region Metodos
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 4));

        }

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
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
#endregion
    }
}
