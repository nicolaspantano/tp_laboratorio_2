using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);                
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);                
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);                
            }
        }
        #endregion

        #region Constructores
        public Persona():this("","",ENacionalidad.Argentino)            
        {

        }

        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
            
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni,ENacionalidad nacionalidad)
            :this(nombre,apellido,dni.ToString(),nacionalidad)
        {
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
           
            this.StringToDNI = dni;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retorna la descripcion de la instancia</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NOMBRE COMPLETO: ");
            sb.Append(this.Apellido);
            sb.Append(", ");
            sb.AppendLine(this.Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(this.Nacionalidad.ToString());
            sb.Append("DNI: ");
            sb.AppendLine(this.DNI.ToString());

            return sb.ToString();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dato">El nombre a ser validado</param>
        /// <returns>El dato validado</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char actual in dato)
            {
                if (char.IsNumber(actual) || char.IsDigit(actual))
                {
                    throw new Exception("Cadena invalida para campos de nombre");
                }
            }
            return dato;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">d}DNI de la persona</param>
        /// <returns>El dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            
            return ValidarDni(nacionalidad, dato.ToString());                       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>El dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int contador=0;
            foreach(char a in dato)
            {
                contador++;
                if (char.IsLetter(a)||char.IsSymbol(a))
                {
                    throw new DniInvalidoException();
                }
            }
            if (contador > 8)
            {
                throw new DniInvalidoException();
            }


            int aux = Convert.ToInt32(dato);
            if (aux < 1)
            {
                throw new DniInvalidoException();
            }

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (aux >= 1 && aux <= 89999999)
                    {
                        return aux;
                    }
                    break;

                case ENacionalidad.Extranjero:
                    if (aux <= 99999999 && aux >= 90000000)
                    {
                        return aux;
                    }
                    break;
                
            }
            throw new NacionalidadInvalidaException();                                    

        }

#endregion
    }
}
