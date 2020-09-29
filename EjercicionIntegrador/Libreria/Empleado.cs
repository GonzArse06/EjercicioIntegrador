using Consola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Empleado:Persona
    {
        private DateTime _fechaIngreso;
        private int _legajo;
        private List<Salario> _salarios;

        public void AgregarSalario()
        { }
        public override bool Equals(object a)
        {
            return true;
        }
        public string GetCredencial()
        {
            return "";
        }
        public string GetNombreCompleto()
        {
            return "";
        }
        public override string ToString()
        {
            return base.ToString();
        }

        //propiedades
        public int Antiguedad
        { get; set; }
        public DateTime FechaIngreso
        { get; set; }

        public DateTime FechaNacimiento
        { get; set; }
        public int Legajo
        { get { return this._legajo; } set { this._legajo = value; } }
        public List<Salario> Salarios
        { get { return this._salarios; } set { this._salarios = value; } }
        public Salario UltimoSalario
        { get; set; }
    }
}
