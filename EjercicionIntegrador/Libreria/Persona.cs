﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    class Persona
    {
        private string _apellido;
        private DateTime _fechaNac;
        private string _nombre;

        public string GetCredencial()
        {
            return "";
        }
        public string GetNombreCompleto()
        {
            return "";
        }
        public string Apellido { get { return this._apellido; } set { this._apellido = value; } }

        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }

        public int Edad { get { return DateTime.Now.Year - this._fechaNac.Year; }

    }
}