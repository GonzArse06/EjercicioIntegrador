using Consola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Alumno:Persona
    {
        private int _codigo;
        private string _credencial;
        public int Codigo { get { return this._codigo; }}
        public string Credencial { get { return this._credencial; } set { this._credencial = value; } }

        public string GetCredenciales()
        {
            return "";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
