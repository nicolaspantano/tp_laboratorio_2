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


    }
}
