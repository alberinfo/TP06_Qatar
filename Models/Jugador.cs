using TP06_Qatar.csproj;
using System.Collection.Generic;

namespace TP06_Qatar.models
{
    class Jugador
    {
        private int _idJugador;
        private int _idEquipo;
        private string _nombre;
        private DateTime _fechaNacimiento;
        private string _foto;
        private string _equipoActual;

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
            get { return Nombre; }
            set { Nombre = value; }
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

        Jugador()
        {
            IdJugador = -1;
            IdEquipo = -1;
            Nombre = "";
            FechaNacimiento = DateTime.Parse("1/1/1"); //Good luck with this
            Foto = "";
            EquipoActual = "";
        }

        Equipo(int idj, int ide, string nom, DateTime fna, string foto, string equipo)
        {
            IdJugador = idj;
            IdEquipo = ide;
            Nombre = nom;
            FechaNacimiento = fna; //Good luck with this
            Foto = foto;
            EquipoActual = equipo;
        }
    }
}