using System;

namespace Entidades
{
    public class Numero
    {
        #region Atributo
        private double numero;
        #endregion

        #region Constructores
        public Numero() : this(0)
        {
            
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Propiedad
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion
        
        #region Sobrecarga de operadores

        public static double operator +(Numero num1,Numero num2)
        {
            return num1.numero + num2.numero;
        }
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;

        }
        public static double operator /(Numero num1, Numero num2)
        {
            if (num2.numero != 0)
            {
                return num1.numero / num2.numero;

            }
            else
            {
                return double.MinValue;
            }
        }
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el numero se pueda convertir a double
        /// </summary>
        /// <param name="strNumero">Numero que se intentara convertir</param>
        /// <returns>Retorna el numero convertido o "0"</returns>
        private double ValidarNumero(string strNumero)
        {
            double salida;
            if (double.TryParse(strNumero, out salida))
            {
                return salida;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Convierte un numero de tipo double a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el numero en binario o "Valor Invalido</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";

            int numeroEntero=(int)numero;
            if (numeroEntero == 0)
            {
                return "0";
            }
            else if (numeroEntero < 0)
            {
                numeroEntero = numeroEntero * (-1);
            }

            while (numeroEntero >= 1)
            {
                if (numeroEntero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                numeroEntero = numeroEntero / 2;
            }


            return binario;
        }
        /// <summary>
        /// Convierte un numero de tipo string a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el numero en binario o "Valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            
            double convertido;
            

            if (double.TryParse(numero, out convertido))
            {
                
                                    
                    return DecimalBinario(convertido);
                
                
            }
            else
            {
                return "Valor invalido";
            }
            

           
        }

        /// <summary>
        /// Convierte un numero de binario a decimal
        /// </summary>
        /// <param name="binario">Numero binario</param>
        /// <returns>Retorna el numero convertido</returns>
        public static string BinarioDecimal(string binario)
        {
            double doble = 0;

            int exponente = 0;

            for (int i = (binario.Length) - 1; i >= 0; i--)
            {

                if (binario[i] == '1')
                {                   
                        doble += Math.Pow(2, exponente);                 
                }

                exponente++;
            }
            return doble.ToString();

        }
         #endregion


    }
}
