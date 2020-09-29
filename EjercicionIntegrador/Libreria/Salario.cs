using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Salario
    {
        private double _bruto;
        private string _codigoTransferencia;
        private double _descuento;
        private DateTime _fecha;

        public double GetSalarioNeto()
        {
            return 1.2d;
        }
        public Salario(double a)
        {

        }
        public string Bruto { get { return this._bruto; } set { this._bruto = value; } }

        public string CodigoTransferencia { get { return this._codigoTransferencia; } set { this._codigoTransferencia = value; } }

        public string Descuento { get { return this._descuento; } set { this._descuento= value; } }

        public string Fecha { get { return this._fecha; } set { this._fecha= value; } }


    }
}
