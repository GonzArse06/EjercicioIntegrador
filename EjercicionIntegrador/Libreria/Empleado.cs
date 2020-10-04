using Consola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public abstract class Empleado:Persona
    {
        private DateTime _fechaIngreso;
        private int _legajo;
        private List<Salario> _salarios;
        private Salario _ultimoSalario;

        public Empleado(string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso):base(nombre, apellido, fecha)
        {
            this._legajo = legajo;
            this._fechaIngreso = fechaingreso;
            this._salarios = new List<Salario>();
        }

        public void AgregarSalario(double bruto) //UML: AgregarSalario(Salario):void
        {
            this._ultimoSalario = new Salario(bruto);
            this._salarios.Add(this._ultimoSalario);
        }
        public override bool Equals(object a)
        {
            if (a == null)
                return false;
            if (!(a is Empleado)) // otra forma de hacerlo es: if(obj.GetType() != typeOf(docente)
                return false;
            if (this._legajo == ((Empleado)a).Legajo)
                return true;
            else
                return false;
        }
        public string GetCredencial()
        {
            return string.Format("{0} - {1} Salario ${2}",this.Legajo, GetNombreCompleto(),this.UltimoSalario.GetSalarioNeto().ToString("0.##"));
        }
        public override string GetNombreCompleto()
        {
            return base.GetNombreCompleto();
        }
        public string GetNombreBusqueda()//cree el metodo porque no puedo hacer que el GetNombreCompleto me traiga la informacion de persona
        {
            return base.GetNombreCompleto();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //propiedades
        public int Antiguedad
        { get { return DateTime.Now.Year - this._fechaIngreso.Year; } }
        public DateTime FechaIngreso
        { get { return this._fechaIngreso; } set { this._fechaIngreso = value; } }
        public DateTime FechaNacimiento
        { get { return FechaNacimiento; } set { FechaNacimiento = value; } }
        public int Legajo
        { get { return this._legajo; } set { this._legajo = value; } }
        public List<Salario> Salarios
        { get { return this._salarios; } set { this._salarios = value; } }
        public Salario UltimoSalario
        { get { return _ultimoSalario; } }



    }
}
