using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Libreria;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {             
            Facultad facultad = new Facultad();
            int opcion=0;
            CargaInicial(facultad);
            do
            {
                opcion = ConsoleHelper.MenuInicial();
                switch (opcion)
                {
                    case (int)Menu.AgregarAlumno:
                        ConsoleHelper.MenuOpcion(opcion);
                        AgregarAlumno(facultad);
                        break;
                    case (int)Menu.AgregarEmpleado:
                        ConsoleHelper.MenuOpcion(opcion);
                        AgregarEmpleado(facultad);
                        break;
                    case (int)Menu.ModificarEmpleado:
                        ConsoleHelper.MenuOpcion(opcion);
                        ModificarEmpleado(facultad);
                        break;
                    case (int)Menu.EliminarAlumno:
                        ConsoleHelper.MenuOpcion(opcion);
                        EliminarAlumno(facultad);
                        break;
                    case (int)Menu.EliminarEmpleado:
                        ConsoleHelper.MenuOpcion(opcion);
                        EliminarEmpleado(facultad);
                        break;
                    case (int)Menu.ListarTodosLosAlumnos:
                        ConsoleHelper.MenuOpcion(opcion);
                        ListarTodosLosAlumnos(facultad);
                        break;
                    case (int)Menu.ListarTodosLosEmpleados:
                        ConsoleHelper.MenuOpcion(opcion);
                        ListarTodosLosEmpleados(facultad);
                        break;
                    case (int)Menu.ListarEmpleadosPorNombre:
                        ConsoleHelper.MenuOpcion(opcion);
                        ListarEmpleadosPorNombre(facultad);
                        break;
                    case (int)Menu.ListarEmpleadosPorLegajo:
                        ConsoleHelper.MenuOpcion(opcion);
                        ListarEmpleadosPorLegajo(facultad);
                        break;
                    case (int)Menu.Salir:
                        break;
                        
                }
                if (opcion == (int)Menu.Salir)
                {
                    Console.WriteLine("Gracias por usar ProgramArse....\nHasta Luego :)");
                    Thread.Sleep(5000);
                }
                else
                {
                    Console.WriteLine("Enter para continuar....");
                    Console.ReadKey();
                }    
            } while (opcion != (int)Menu.Salir); //podria usar un enumerado para colocar las opciones del menu            
        }

        static void AgregarAlumno(Facultad facultad)
        {
            string nombre = Validaciones.Texto("nombre");
            string apellido = Validaciones.Texto("apellido");
            DateTime fechaNac = Validaciones.Fecha("fecha de nacimiento");
            int codigo = Validaciones.Entero("codigo",Validaciones.minCodigo, Validaciones.maxCodigo);
            try
            {
                facultad.AgregarAlumno(nombre, apellido, fechaNac, codigo);
                Console.WriteLine("Alumno agregado exitosamente!");
            }
            catch (DuplicadoException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
        }
        static void AgregarEmpleado(Facultad facultad)
        {
            string nombre = Validaciones.Texto("nombre");
            string apellido = Validaciones.Texto("apellido");
            DateTime fechaNac = Validaciones.Fecha("fecha de nacimiento");
            int legajo = Validaciones.Entero("legajo", Validaciones.minLegajo, Validaciones.maxLegajo);
            DateTime fechaIngreso = Validaciones.Fecha("fecha de ingreso");
            int tipo = ConsoleHelper.MenuTipoEmpleado();
            double salario = Validaciones.Importe("salario bruto", 1, 99999999);
            try
            {
                if (tipo == (int)TipoEmpleado.Directivo || tipo == (int)TipoEmpleado.Docente)
                    facultad.AgregarEmpleado(tipo, nombre, apellido, fechaNac, legajo, fechaIngreso, "", salario);
                if (tipo == (int)TipoEmpleado.Bedel)
                {
                    string apodo = Validaciones.Texto("apodo");
                    facultad.AgregarEmpleado(tipo, nombre, apellido, fechaNac, legajo, fechaIngreso, apodo, salario);
                }
                Console.WriteLine("Empleado "+Enum.GetName(typeof(TipoEmpleado),tipo)+" agregado exitosamente!");

            }
            catch (DuplicadoException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }

        }
        public static void ListarTodosLosAlumnos(Facultad facultad)
        {
            List<Alumno> alumnos = facultad.TraerAlumnos();
            foreach (Alumno a in alumnos)
            {
                Console.WriteLine(a.GetCredenciales());
            }
        }
        public static void ListarTodosLosEmpleados(Facultad facultad)
        {
            List<Empleado> empleados = facultad.TraerEmpleados();
            foreach (Empleado a in empleados)
            {
                if(a is Bedel)
                    Console.WriteLine(((Bedel)a).GetCredencial());
                if (a is Docente)
                    Console.WriteLine(((Docente)a).GetCredencial());
                if (a is Directivo)
                    Console.WriteLine(((Directivo)a).GetCredencial());
            }
        }
        public static void ListarEmpleadosPorLegajo(Facultad facultad)
        {
            ListarTodosLosEmpleados(facultad);
            int legajo = Validaciones.Entero("legajo", Validaciones.minLegajo, Validaciones.maxLegajo);
            Empleado empleado = facultad.TraerEmpleadoPorLegajo(legajo);
            if (empleado == null)
                Console.WriteLine("No hay empleado con ese legajo");
            else
            {
                if (empleado is Bedel)
                    Console.WriteLine(((Bedel)empleado).GetCredencial());
                if (empleado is Docente)
                    Console.WriteLine(((Docente)empleado).GetCredencial());
                if (empleado is Directivo)
                    Console.WriteLine(((Directivo)empleado).GetCredencial());
            }
        }
        public static void ListarEmpleadosPorNombre(Facultad facultad)
        {
            string nombre = Validaciones.Texto("el nombre o apellido del empleado a buscar");
            List<Empleado> empleado = facultad.TraerEmpleadosPorNombre(nombre);
            if (empleado.Count == 0)
                Console.WriteLine("No hay empleado con ese legajo");
            else
            {
                foreach(Empleado a in empleado)
                {
                    Console.WriteLine(a.GetCredencial());
                }
            }
        }

        public static void ModificarEmpleado(Facultad facultad)
        {            
            string nombre;
            string apellido;
            DateTime fechaNac;
            DateTime fechaIngreso;
            string apodo="";

            ListarTodosLosEmpleados(facultad);
            Empleado empleado = facultad.TraerEmpleadoPorLegajo(Validaciones.Entero("legajo", Validaciones.minLegajo, Validaciones.maxLegajo));
            if (empleado == null)
                Console.WriteLine("No hay empleado con ese legajo");
            else
            {
                Console.WriteLine("Desea cambiar el nombre "+empleado.Nombre+"? Ingrese S si desea cambiarlo....");
                if (Console.ReadLine().ToLower() == "s")
                    nombre = Validaciones.Texto("nuevo nombre");
                else
                    nombre = empleado.Nombre;

                Console.WriteLine("Desea cambiar el apellido " + empleado.Apellido + "? Ingrese S si desea cambiarlo....");
                if (Console.ReadLine().ToLower() == "s")
                    apellido = Validaciones.Texto("nuevo apellido");
                else
                    apellido = empleado.Apellido;

                Console.WriteLine("Desea cambiar la fecha de nacimiento " + empleado.FechaNacimiento.ToString("DD/MM/YYYY") + "? Ingrese S si desea cambiarlo....");
                if (Console.ReadLine().ToLower() == "s")
                    fechaNac = Validaciones.Fecha("nueva fecha de nacimiento");
                else
                    fechaNac = empleado.FechaNacimiento;

                Console.WriteLine("Desea cambiar la fecha de ingreso " + empleado.FechaIngreso.ToString("dd/MM/YYYY") + "? Ingrese S si desea cambiarlo....");
                if (Console.ReadLine().ToLower() == "s")
                    fechaIngreso = Validaciones.Fecha("nueva fecha de ingreso");
                else
                    fechaIngreso = empleado.FechaIngreso;

                if (empleado is Bedel)
                {
                    Bedel empleadoAux = (Bedel)empleado;
                    Console.WriteLine("Desea cambiar el apodo " + empleadoAux.Apodo + "? Ingrese S si desea cambiarlo....");
                    if (Console.ReadLine().ToLower() == "s")
                        apodo = Validaciones.Texto("nuevo apodo");
                    else
                        apodo = empleadoAux.Apodo;
                }

                try
                {
                    facultad.ModificarEmpleado(nombre, apellido, fechaNac, empleado.Legajo, fechaIngreso, apodo);
                    Console.WriteLine("El Empleado se modifico con exito!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error - " + e.Message);
                }



            }
        }

        public static void EliminarAlumno(Facultad facultad)
        {
            try
            {
                facultad.EliminarAlumno(Validaciones.Entero("codigo de alumno", Validaciones.minCodigo, Validaciones.maxCodigo));
                Console.WriteLine("El Alumno se elimino con exito!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
        }
        public static void EliminarEmpleado(Facultad facultad)
        {
            try
            {
                facultad.EliminarEmpleado(Validaciones.Entero("legajo del empleado", Validaciones.minLegajo, Validaciones.maxLegajo));
                Console.WriteLine("El Empleado se elimino con exito!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
        }

        //Carga inicial para valiciones
        public static void CargaInicial(Facultad facultad)
        {
            facultad.AgregarAlumno("Gonzalo", "Carranza", DateTime.Parse("1988-03-02"), 1234);
            facultad.AgregarAlumno("Andrea", "Amatrudo", DateTime.Parse("1987-01-08"), 1235);
            facultad.AgregarAlumno("Sofia", "Carranza", DateTime.Parse("2017-11-13"), 1236);

            facultad.AgregarEmpleado((int)TipoEmpleado.Bedel, "Raul", "Carranza", DateTime.Parse("1967-09-22"), 2000, DateTime.Parse("2020-01-01"), "Cera", 100000d);
            facultad.AgregarEmpleado((int)TipoEmpleado.Directivo, "Beatriz", "Rojas", DateTime.Parse("1967-09-22"), 2001, DateTime.Parse("2020-01-01"), "", 90000d);
            facultad.AgregarEmpleado((int)TipoEmpleado.Docente, "Facundo", "Carranza", DateTime.Parse("1967-09-22"), 2002, DateTime.Parse("2020-01-01"), "", 50000d);
            facultad.AgregarEmpleado((int)TipoEmpleado.Docente, "Mandy", "Perro", DateTime.Parse("1967-09-22"), 2003, DateTime.Parse("2020-01-01"), "", 10000d);

        }

    }
}
