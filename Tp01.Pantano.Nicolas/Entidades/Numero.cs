using System;

namespace Entidades
{
    public class Numero
    {
        
        private double numero;

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

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

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


    }
}
