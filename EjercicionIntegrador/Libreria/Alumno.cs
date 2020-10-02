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
    public class Alumno : Persona
    {
        private int _codigo;

        public Alumno(string nombre, string apellido, DateTime fecha, int codigo) : base(nombre, apellido, fecha)
        {
            this._codigo = codigo;
        }

        public int Codigo { get { return this._codigo; }}

        public string GetCredenciales()
        {
            return string.Format("Codigo {0} - {1}, {2}",this._codigo,base.Apellido,base.Nombre);
        }
        public override string ToString()
        {
            return this.GetCredenciales();
        }
    }
}
