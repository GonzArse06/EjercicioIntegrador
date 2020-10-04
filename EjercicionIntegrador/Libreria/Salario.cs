using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Salario
    {
        const double _jubilacion = 0.11f;
        const double _osocial = 0.03f;
        const double _insspj = 0.03f;

        private double _bruto;
        private string _codigoTransferencia;
        private double _descuento;
        private DateTime _fecha;

        public double GetSalarioNeto()
        {
            return this._bruto * (1 - _jubilacion -_osocial-_insspj);
        }
        public Salario(double a)
        {
            this._bruto = a;
            this._fecha = DateTime.Now;
            this._descuento = 0.17d;
            this._codigoTransferencia = "1";
        }
        public double Bruto { get { return this._bruto; } set { this._bruto = value; } }

        public string CodigoTransferencia { get { return this._codigoTransferencia; } set { this._codigoTransferencia = value; } }

        public double Descuento { get { return this._descuento; } set { this._descuento= value; } }

        public DateTime Fecha { get { return this._fecha; } set { this._fecha= value; } }


    }
}
