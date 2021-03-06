﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
            
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Verifica si el alumno esta en la jornada
        /// </summary>
        /// <param name="j">La jornada</param>
        /// <param name="a">El alumno</param>
        /// <returns>Retorna true si el alumno esta en la jornada</returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            foreach(Alumno actual in j.Alumnos)
            {
                if (actual.DNI == a.DNI)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si el alumno no esta en la jornada
        /// </summary>
        /// <param name="j">La jornada</param>
        /// <param name="a">El alumno</param>
        /// <returns>Retorna true si el alumno esta en la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Añade el alumno a la jornada
        /// </summary>
        /// <param name="j">La jornada</param>
        /// <param name="a">El alumno</param>
        /// <returns>Retorna la jornada</returns>
        public static Jornada operator +(Jornada j,Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            else
            {
                throw new Excepciones.AlumnoRepetidoException();
            }
            return j;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda la informacion en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a ser guardada</param>
        /// <returns>Retorna true si se pudo guardar</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <returns>Retorna la informacion</returns>
        public static string Leer()
        {
            string retorno;
            Texto texto = new Texto();
            texto.Leer("Jornada.txt",out retorno);
            return retorno;
        }

        /// <summary>
        /// Da informacion de la jornada
        /// </summary>
        /// <returns>Devuelve la informacion</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.Append("CLASE DE ");
            sb.Append(this.Clase);
            sb.Append(" POR ");
            sb.AppendLine(this.Instructor.ToString());

            sb.AppendLine("ALUMNOS:");

            foreach(Alumno actual in this.Alumnos)
            {
                sb.AppendLine(actual.ToString());
            }

            sb.Append("<");
            sb.Append('-', 48);
            sb.AppendLine(">");

            return sb.ToString();
        }
#endregion


    }
}
