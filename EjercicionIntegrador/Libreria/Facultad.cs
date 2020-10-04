using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
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

        public Facultad()
        {
            _alumnos = new List<Alumno>();
            _empleados = new List<Empleado>();
        }

        private void AgregarAlumno(Alumno a)
        {
            this._alumnos.Add(a);
        }
        public void AgregarAlumno(string nombre, string apellido, DateTime fecha, int codigo)
        {
            Alumno aux = new Alumno(nombre, apellido, fecha, codigo);
            foreach (Alumno a in _alumnos)
            {
                if (a.Equals(aux))
                    throw new DuplicadoException("El codigo de Alumno ya se encuentra registrado.");
            }
            this.AgregarAlumno(aux);
        }

        public void AgregarEmpleado(Empleado a)
        {
            this._empleados.Add(a);
        }
        public void AgregarEmpleado(int tipo, string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso, string apodo, double salario)
        {
            Empleado empleado=null;
            switch (tipo)
            {
                case (int)TipoEmpleado.Docente:
                    empleado = new Docente(nombre, apellido, fecha, legajo, fechaingreso);
                    break;
                case (int)TipoEmpleado.Directivo:
                    empleado = new Directivo(nombre, apellido, fecha, legajo, fechaingreso);
                    break;
                case (int)TipoEmpleado.Bedel:
                    empleado = new Bedel(nombre, apellido, fecha, legajo, fechaingreso, apodo);
                    break;
            }

            foreach (Empleado a in _empleados)
            {
                if (a.Equals(empleado))
                    throw new DuplicadoException("El legado de empleado ya se encuentra cargado");
            }
            this._empleados.Add(empleado);
            empleado.AgregarSalario(salario);

        }       

        public void EliminarAlumno(int a)
        {
            Alumno alumno = this._alumnos.SingleOrDefault(x => x.Codigo == a);
            if (alumno != null)
                this._alumnos.Remove(alumno);
            else
            {
                throw new Exception("El Alumno no esta registrado");
            }            
        }
        public void EliminarEmpleado(int a)
        {
            Empleado empleado = this._empleados.SingleOrDefault(x => x.Legajo == a);
            if (empleado == null)
                throw new Exception("El empleado no esta registrado");
            else
                this._empleados.Remove(empleado);
        }
        public void ModificarEmpleado(Empleado a)
        {
            //USar: RemoveAt(Int32) y antes tengo que IndexOf(T) para tener el indice
            //o: Remove(T) el T original y agrego el nuevo objeto.


            //primero mostrar el listado de todos los empleados. despues pedir que elijan un codigo. luego iterar cada dato y preguntar que dato quiere modificar
            //ej. muestre nombre, desea modificar? si, ponga nuevo nombre. sino darle enter.
        }
        public void ModificarEmpleado(string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso, string apodo)
        {
            Empleado empleado = TraerEmpleadoPorLegajo(legajo);

            if (empleado == null)
                throw new Exception("El legajo no existe");
            else
            { 
                empleado.Nombre = nombre;
                empleado.Apellido = apellido;
                empleado.FechaNacimiento = fecha;
                empleado.FechaIngreso = fechaingreso;
                if (empleado is Bedel)
                    ((Bedel)empleado).Apodo = apodo;
            }

        }

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
                if (a.GetNombreBusqueda().ToLower().Contains(nombre.ToLower()))//usar contains
                    _listado.Add(a);
            }
            return _listado;
            //Buscar por expresiones landas this.empleado.where(x => x.getcredencial().tolower().contains(text)).tolist();
            //esto es para que te vuelva uno solo: this.empleado.singleofdefault(x => x.getcredencial().tolower().contains(text))
        }

        public int CantidadSedes
        {
            get { return this._cantidadSedes; }
            set { this._cantidadSedes = value; }
        }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }


    }
}
