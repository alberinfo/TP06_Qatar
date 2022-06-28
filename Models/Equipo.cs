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
        private string _continente;
        private int _copasGanadas;

        public int IdEquipo
        {
            get { return _idEquipo; }
            set { _idEquipo = value; }
        }

        public string Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string Escudo
        {
            get { return Escudo; }
            set { Escudo = value; }
        }

        public string Camiseta
        {
            get { return Camiseta; }
            set { Camiseta = value; }
        }

        public string Continente
        {
            get { return Continente; }
            set { Continente = value; }
        }

        public int CopasGanadas
        {
            get { return CopasGanadas; }
            set { CopasGanadas = value; }
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