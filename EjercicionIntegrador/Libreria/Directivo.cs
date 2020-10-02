using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Directivo:Empleado
    {
        public Directivo(string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso) : base(nombre, apellido, fecha, legajo, fechaingreso)
        {
        }
        public override string GetNombreCompleto()
        { return "Sr. Director "+base.Apellido; }
    }
}
