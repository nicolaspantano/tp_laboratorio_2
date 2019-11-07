using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Enumerado
        public enum EClases
        {
            Programacion,Laboratorio,Legislacion,SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Constructor
        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Comprueba si un alumno va a una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno va a esa universidad</returns>
        public static bool operator ==(Universidad g,Alumno a)
        {
            if(!(g.Equals(null))&&!(a is null))
            {
                foreach (Alumno actual in g.Alumnos)
                {
                    if (actual.DNI == a.DNI)
                    {
                        return true;
                    }
                }
            }
            

            return false;
        }

        /// <summary>
        /// Comprueba si un alumno no va a una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno no va a esa universidad</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Comprueba si un profesor trabaja en una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Retorna true si el profesor trabaja en esa universidad</returns>
        public static bool operator ==(Universidad g,Profesor i)
        {
            if(!(g is null)&&!(i is null))
            {
                foreach (Profesor actual in g.Instructores)
                {
                    if (actual == i)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// Comprueba si un profesor no trabaja en una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Retorna true si el profesor no trabaja en esa universidad</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Otorga profesor disponile para dar esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna el profesor</returns>
        public static Profesor operator ==(Universidad u,EClases clase)
        {                        
                foreach (Profesor actual in u.Instructores)
                {
                    if (actual == clase)
                    {
                        return actual;
                    }
                }                                    
                throw new SinProfesorException();                        
        }

        /// <summary>
        /// Otorga profesor que no puede dar esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna el profesor</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {                        
                foreach(Profesor actual in u.Instructores)
                {
                    if(actual != clase)
                    {
                        return actual;
                    }
                }
            return null;            
        }

        /// <summary>
        /// Añade una clase a una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad g,EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);
            foreach(Alumno actual in g.Alumnos)
            {
                if (actual == clase)
                {
                    j += actual;
                }
            }

            g.Jornadas.Add(j);
            return g;            
        }

        /// <summary>
        /// Añade un alumno a la universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad u,Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
            
        }

        public static Universidad operator +(Universidad u,Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Da informacion de la universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Retorna la informacion</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada actual in uni.Jornadas)
            {
                sb.AppendLine(actual.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Da informacion de la universidad
        /// </summary>
        /// <returns>Retorna la informacion</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Guarda la informacion en una archivo .xml
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Retorna true si lo pudo guardar</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
                                                    
        }

        /// <summary>
        /// Lee informacion de un archivo .xml
        /// </summary>
        /// <returns>Retorna la informacion</returns>
        public Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out uni);
            return uni;
        }
#endregion

    } 
}
