using System.Collections.Generic;
using System;

namespace TP06_Qatar.Models
{
    public class Continente
    {
        private int _idContinente;
        private string _nombre;

        public int IdContinente
        {
            get { return _idContinente; }
            set { _idContinente = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}