using System.Collections.Generic;
using System;
namespace TP06_Qatar.Models
{
    public class Equipo
    {
        private int _idEquipo;
        private string _nombre;
        private string _escudo;
        private string _camiseta;
        private string _Continente;
        private int _copasGanadas;

        public int IdEquipo
        {
            get { return _idEquipo; }
            set { _idEquipo = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Escudo
        {
            get { return _escudo; }
            set { _escudo = value; }
        }

        public string Camiseta
        {
            get { return _camiseta; }
            set { _camiseta = value; }
        }

        public string Continente
        {
            get { return _Continente; }
            set { _Continente = value; }
        }

        public int CopasGanadas
        {
            get { return _copasGanadas; }
            set { _copasGanadas = value; }
        }

        public Equipo()
        {
            IdEquipo = -1;
            Nombre = "";
            Escudo = "";
            Camiseta = "";
            Continente = "";
            CopasGanadas = 0;
        }

        public Equipo(int id, string nom, string esc, string cam, string cont, int cop)
        {
            IdEquipo = id;
            Nombre = nom;
            Escudo = esc;
            Camiseta = cam;
            Continente = cont;
            CopasGanadas = cop;
        }
    }
}