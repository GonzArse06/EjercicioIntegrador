using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Libreria
{
    class Bedel:Empleado
    {
        private string _apodo;
        public string GetNombreCompleto()
        {
            return "";
        }
        public string Apodo
        { get { return this._apodo; } set { this._apodo = value; } }
    }
}
