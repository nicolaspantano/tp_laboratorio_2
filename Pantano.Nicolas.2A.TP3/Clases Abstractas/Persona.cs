using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Persona()
            :this("SinNombre","SinApellido",null,ENacionalidad.Argentino)
        {

        }

        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
            :this(nombre,apellido,null,nacionalidad)
        {

        }

        public Persona(string nombre, string apellido,int dni,ENacionalidad nacionalidad)
            :this(nombre,apellido,dni.ToString(),nacionalidad)
        {
            
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.StringToDNI = dni;
            this.Nacionalidad = nacionalidad;
        }
        #endregion

        #region Sobrecargas
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre: ");
            sb.Append(this.Nombre);
            sb.Append(", ");
            sb.AppendLine(this.Apellido);
            sb.Append("Nacionalidad: ");
            sb.AppendLine(this.Nacionalidad.ToString());
            sb.Append("DNI: ");
            sb.AppendLine(this.DNI.ToString());

            return sb.ToString();
        }
        #endregion

        #region Metodos
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

        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }

        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int i = 0;
            int aux;            
            foreach (char actual in dato)
            {
                i++;
                if (char.IsLetterOrDigit(actual) || i > 8)
                {
                    throw new Excepciones.DniInvalidoException();
                }
            }
            
            aux = Convert.ToInt32(dato);

            if (this.nacionalidad == ENacionalidad.Argentino && aux <= 89999999 && aux >= 1)
            {
                return aux;
            }
            else if (this.nacionalidad == ENacionalidad.Extranjero && aux >= 90000000 && aux <= 99999999)
            {
                return aux;
            }
            else
            {
                throw new Excepciones.NacionalidadInvalidaException();
            }

        }

#endregion
    }
}
