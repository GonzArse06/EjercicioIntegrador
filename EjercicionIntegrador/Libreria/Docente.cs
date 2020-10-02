using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Docente:Empleado
    {
        public Docente(string nombre, string apellido, DateTime fecha, int legajo, DateTime fechaingreso) : base(nombre, apellido, fecha,legajo,fechaingreso)
        {            
        }
        public override string GetNombreCompleto()
        { return "Docente "+base.Nombre; }
    }
}
