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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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


        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada actual in uni.Jornadas)
            {
                sb.AppendLine(actual.ToString());
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
                                                    
        }

        public Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out uni);
            return uni;
        }

    } 
}
