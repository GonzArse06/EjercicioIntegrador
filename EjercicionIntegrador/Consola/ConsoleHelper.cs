using Libreria;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    public static class ConsoleHelper
    {
        public static void PedirDatos(string mensaje)
        {
            Console.Write("Ingresar " + mensaje + ": ");
        }
        public static void MensajeError(string mensaje)
        {
            Console.WriteLine("Error. Reingrese " + mensaje + ": ");
        }
        public static void MensajeErrorTipoDato(string mensaje, string tipo)
        {
            Console.WriteLine("Error. Debe ingresar "+ tipo +". Reingrese " + mensaje + ": ");
        }
        public static int MenuInicial()
        {
            int retorno;
            int[] num = (int[])Enum.GetValues(typeof(Menu));
            string[] nombre = Enum.GetNames(typeof(Menu));

            int minMenu= num.GetLowerBound(0)+1;
            int maxMenu = num.GetUpperBound(0)+1;
            string menu = "************************ MENU FACULTAD ************************";
            
            int pos = 0;
            while (pos <= num.GetUpperBound(0))
            {
                menu +="\n"+ num[pos].ToString() + " " + nombre[pos];
                pos++;
            }
            
            Console.Clear();
            Console.WriteLine(menu);
            retorno = Validaciones.Entero("una opcion", minMenu, maxMenu);
            return retorno;        
        }
        public static int MenuTipoEmpleado()
        {
            int retorno;
            int[] num = (int[])Enum.GetValues(typeof(TipoEmpleado));
            string[] nombres = Enum.GetNames(typeof(TipoEmpleado));
            int pos = 0;
            while (pos <= num.GetUpperBound(0))
            {
                Console.WriteLine(num[pos] + " - " + nombres[pos]);
                pos++;
            }
            retorno = Validaciones.Entero("tipo empleado", Enum.GetValues(typeof(TipoEmpleado)).GetLowerBound(0)+1, Enum.GetValues(typeof(TipoEmpleado)).GetUpperBound(0)+1);
            return retorno;
        }
        public static void MenuOpcion(int opcion)
        {
            string menuOpcion = "************************ ";
            switch (opcion)
            {
                case (int)Menu.AgregarAlumno:
                    menuOpcion += "AGREGAR ALUMNO";
                    break;
                case (int)Menu.AgregarEmpleado:
                    menuOpcion += "AGREGAR EMPLEADO";
                    break;
                case (int)Menu.ModificarEmpleado:
                    menuOpcion += "MODIFICAR EMPLEADO";
                    break;
                case (int)Menu.EliminarAlumno:
                    menuOpcion += "ELIMINAR ALUMNO";
                    break;
                case (int)Menu.EliminarEmpleado:
                    menuOpcion += "ELIMINAR EMPLEADO";
                    break;
                case (int)Menu.ListarTodosLosAlumnos:
                    menuOpcion += "LISTAR TODOS LOS ALUMNOS";
                    break;
                case (int)Menu.ListarTodosLosEmpleados:
                    menuOpcion += "LISTAR TODOS LOS EMPLEADOS";
                    break;
                case (int)Menu.ListarEmpleadosPorNombre:
                    menuOpcion += "LISTAR EMPLEADOS POR NOMBRE";
                    break;
                case (int)Menu.ListarEmpleadosPorLegajo:
                    menuOpcion += "LISTAR EMPLEADOS POR LEGAJO";
                    break;
                case (int)Menu.Salir:
                    menuOpcion += "SALIR";
                    break;
            }
            menuOpcion += "************************";
            Console.WriteLine(menuOpcion);
        }
    }
}
