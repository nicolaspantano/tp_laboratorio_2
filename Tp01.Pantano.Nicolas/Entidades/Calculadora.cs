using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Realiza la operacion indicada entre los numeros
        /// </summary>
        /// <param name="num1">Operando 1</param>
        /// <param name="num2">Operando 2</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "*":
                    return num1 * num2;
                    

                case "-":
                    return num1 - num2;
                    

                case "/":
                    return num1 / num2;


                    //+
                default:
                    return num1 + num2;
                                       
            }
        }

        /// <summary>
        /// Valida que el operador sea "+" "-" "*" "/"
        /// </summary>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Retorna el operador, o en su defecto "+"</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
        #endregion
    }
}
