using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Facultad
    {
        private List<Alumno> _alumnos;
        private int _cantidadSedes;
        private List<Empleado> _empleados;
        private string _nombre;

        public void AgregarAlumno(Alumno a)
        {
            this._alumnos.Add(a);
        }
        public void AgregarAlumno(string nombre, string apellido, DateTime fecha, int codigo)
        {
            this._alumnos.Add(new Alumno(nombre,apellido,fecha,codigo));
        }
        public void AgregarEmpleado(Empleado a)
        {
            this._empleados.Add(a);
        }
        public void AgregarEmpleado(int tipo, string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso)
        {
            Empleado empleado=null;
            switch (tipo)
            {
                case (int)TipoEmpleado.Docente:
                    new Docente(nombre, apellido, fecha, legajo, fechaingreso);
                    break;
                case (int)TipoEmpleado.Directivo:
                    new Directivo(nombre, apellido, fecha, legajo, fechaingreso);
                    break;
            }

            this._empleados.Add(empleado);
        }
        public void AgregarEmpleado(int tipo, string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso,string apodo)
        {
            Empleado empleado = null;
            switch (tipo)
            {
                case (int)TipoEmpleado.Docente:
                    new Bedel(nombre, apellido, fecha, legajo, fechaingreso,apodo);
                    break;
            }
            this._empleados.Add(empleado);
        }

        public void EliminarAlumno(int a)
        {
            this._alumnos.RemoveAt(a);
        }
        public void EliminarEmpleado(int a)
        {
            this._empleados.RemoveAt(a);
        }
        public void ModificarEmpleado(Empleado a)
        { }
        public List<Alumno> TraerAlumnos()
        {
            return this._alumnos;
        }
        public Empleado TraerEmpleadoPorLegajo(int legajo)
        {
            Empleado emp=null;
            foreach (Empleado a in _empleados)
            {
                if (a.Legajo == legajo)
                    emp = a;
            }
            return emp;
        }
        public List<Empleado> TraerEmpleados()
        {
            return this._empleados;
        }
        public List<Empleado> TraerEmpleadosPorNombre(string nombre)
        {
            List<Empleado> _listado = new List<Empleado>();
            foreach (Empleado a in _empleados)
            {
                if (a.Nombre == nombre)
                    _listado.Add(a);
            }
            return this._empleados;
        }

        public int CantidadSedes
        {
            get { return this._cantidadSedes; }
            set { this._cantidadSedes = value; }
        }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }


    }
}
