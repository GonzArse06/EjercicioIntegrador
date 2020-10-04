using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class DuplicadoException:Exception
    {
        public DuplicadoException(string mensaje) : base(mensaje)
        { }
    }
}
