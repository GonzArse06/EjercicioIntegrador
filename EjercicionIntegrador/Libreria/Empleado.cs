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

        public Empleado(string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso):base(nombre, apellido, fecha)
        {
            this._legajo = legajo;
            this._fechaIngreso = fechaingreso;
        }

        public void AgregarSalario(double bruto) //UML: AgregarSalario(Salario):void
        {
            this._salarios.Add(new Salario(bruto));
        }
        /*public override bool Equals(object a, object b)
        {
            Empleado _a = (Empleado)a;
            Empleado _b = (Empleado)b;

            if (_a.Legajo == _b.Legajo)
                return true;
            else
                return false;
        }*/
        public string GetCredencial()
        {
            return string.Format("{0} - {1} Salario ${2}",this.Legajo,base.GetNombreCompleto(),this.UltimoSalario) ;
        }
        public abstract string GetNombreCompleto();

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
        { get; set; }
        public int Legajo
        { get { return this._legajo; } set { this._legajo = value; } }
        public List<Salario> Salarios
        { get { return this._salarios; } set { this._salarios = value; } }
        public Salario UltimoSalario
        { get { return _salarios.LastOrDefault(); } }
    }
}
