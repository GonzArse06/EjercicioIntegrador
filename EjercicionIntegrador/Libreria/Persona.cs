using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    public class Persona
    {
        private string _apellido;
        private DateTime _fechaNac;
        private string _nombre;

        public Persona(string nombre, string apellido, DateTime fecha)
        {
            this._apellido = apellido;
            this._nombre = nombre;
            this._fechaNac = fecha;
        }

        public string GetCredencial()
        {
            return "";
        }
        public virtual string GetNombreCompleto()
        {
            return string.Format("{0},{1}",this._apellido,this._nombre);
        }
        

        public string Apellido { get { return this._apellido; } set { this._apellido = value; } }

        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }
        public DateTime FechaNacimiento { get { return this._fechaNac; } set { this._fechaNac = value; } }

        public int Edad { get { return DateTime.Now.Year - this._fechaNac.Year; } } //arreglar esto (hoy - fecha nac).totaldays /365;

    }
}
