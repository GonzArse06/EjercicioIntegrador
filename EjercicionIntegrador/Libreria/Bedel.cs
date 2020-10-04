using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Libreria
{
    public class Bedel:Empleado
    {
        public Bedel(string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso, string apodo) : base(nombre, apellido, fecha, legajo, fechaingreso)
        {
            this._apodo = apodo;
        }
        private string _apodo;
        public override string GetNombreCompleto()
        {
            return "Bedel "+this._apodo;
        }
        public string Apodo
        { get { return this._apodo; } set { this._apodo = value; } }
    }
}
