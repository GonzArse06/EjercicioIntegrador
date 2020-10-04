using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    public static class Validaciones
    {
        const string _datoEntero = "un numero";
        const string _datoFecha = "una fecha";
        const string _datoDouble = "un importe";
        const string _datoString = "un texto";

        public const int minLegajo = 1;
        public const int maxLegajo = 999999;
        public const int minCodigo = 1;
        public const int maxCodigo = 999999;

        public static DateTime Fecha(string mensaje)
        {
            DateTime retorno;
            bool ok = false;
            do
            {
                ConsoleHelper.PedirDatos(mensaje);
                if (!DateTime.TryParse(Console.ReadLine(), out retorno))
                    ConsoleHelper.MensajeErrorTipoDato(mensaje, _datoFecha);
                else
                    ok = true;
            } while (!ok);
            return retorno;
        }
        public static int Entero(string mensaje, int min, int max)
        {
            int retorno;
            do
            {
                ConsoleHelper.PedirDatos(mensaje);
                if (!int.TryParse(Console.ReadLine(), out retorno))
                    ConsoleHelper.MensajeErrorTipoDato(mensaje,_datoEntero);
                if (retorno < min || retorno > max)
                    ConsoleHelper.MensajeError(mensaje);
            } while (retorno < min || retorno > max);
            return retorno;
        }
        public static double Importe(string mensaje, double min, double max)
        {
            double retorno;
            do
            {
                ConsoleHelper.PedirDatos(mensaje);
                if (!double.TryParse(Console.ReadLine(), out retorno))
                    ConsoleHelper.MensajeErrorTipoDato(mensaje, _datoDouble);
                if (retorno < min || retorno > max)
                    ConsoleHelper.MensajeError(mensaje);
            } while (retorno < min || retorno > max);
            return retorno;
        }
        public static string Texto(string mensaje)
        {
            string retorno;
            do
            {
                ConsoleHelper.PedirDatos(mensaje);
                retorno = Console.ReadLine();
                if(string.IsNullOrEmpty(retorno))
                    ConsoleHelper.MensajeErrorTipoDato(mensaje, _datoString);                
            } while (string.IsNullOrEmpty(retorno));
            return retorno;
        }
    }
}
