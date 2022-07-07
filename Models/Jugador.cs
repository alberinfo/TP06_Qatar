using System;
using System.Collections.Generic;

namespace TP06_Qatar.Models
{
    public class Jugador
    {
        private int _numCamiseta;
        private int _idJugador;
        private int _idEquipo;
        private string _nombre;
        private DateTime _fechaNacimiento;
        private string _foto;
        private string _equipoActual;

        public int NumCamiseta
        {
            get { return _numCamiseta; }
            set { _numCamiseta = value; }
        }

        public int IdJugador
        {
            get { return _idJugador; }
            set { _idJugador = value; }
        }

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

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public string EquipoActual
        {
            get { return _equipoActual; }
            set { _equipoActual = value; }
        }

        public Jugador()
        {
            NumCamiseta = -1;
            IdJugador = -1;
            IdEquipo = -1;
            Nombre = "";
            FechaNacimiento = DateTime.Parse("1/1/1"); //Good luck with this
            Foto = "";
            EquipoActual = "";
        }

    }
}