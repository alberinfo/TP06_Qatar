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
        private int _idContinente;
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

        public int IdContinente
        {
            get { return _idContinente; }
            set { _idContinente = value; }
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
            IdContinente = 0;
            CopasGanadas = 0;
        }

        public Equipo(int id, string nom, string esc, string cam, int cont, int cop)
        {
            IdEquipo = id;
            Nombre = nom;
            Escudo = esc;
            Camiseta = cam;
            IdContinente = cont;
            CopasGanadas = cop;
        }
    }
}