using System;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.numero = double.Parse(strNumero);
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

        public double SetNumero
        {
            set { this.numero = value; }
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
                return num1.numero + num2.numero;

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

            while (numero > 1)
            {
                if (numero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                numero = numero / 2;
            }


            return binario;
        }

        public static string DecimalBinario(string numero)
        {
            string binario = "";
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
                    if (i == (binario.Length) - 1)
                    {
                        doble += 1;
                        continue;

                    }
                    else
                    {
                        doble += Math.Pow(2, exponente);

                    }

                }

                exponente++;

            }


            return doble.ToString();

        }


    }
}
