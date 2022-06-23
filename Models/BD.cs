using TP06_Qatar.csproj;
using System.Collection.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace TP06_Qatar.Services
{
    static class BD
    {
        private static string _connectionString = @"Server=A-BTA-02\SQLEXPRESS;DataBase=TP06_Qatar;TrustedConnection=True";

        public static void AgregarJugador(Jugador jug)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "INSERT INTO Jugadores (IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual) VALUES(@IdEquipo, @Nombre, @FechaNacimiento, @Foto, @EquipoActual)";
                int affectedRows = db.Execute<Jugador>(sqlQuery , new {idEquipo = jug.IdEquipo, Nombre = jug.Nombre, FechaNacimiento = Jug.FechaNacimiento, Foto = Jug.Foto, EquipoActual = Jug.EquipoActual});
            }
        }

        public static void EliminarJugador(int idJugador)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "DELETE FROM Jugadores WHERE IdJugador = @pidJugador";
                int affectedRows = db.Execute<Jugador>(sqlQuery , new {pidJugador = idJugador});
            } 
        }

        public static Equipo VerInfoEquipo(int idEquipo)
        {
            Equipo MiEquipo = null;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Equipos WHERE IdEquipo = @pidEquipo";
                MiEquipo = db.QueryFirstOrDefault<Equipo>(sqlQuery, new{pidEquipo = idEquipo});
            }
            return MiEquipo;
        }

        public static Jugador VerInfoJugador(int idJugador)
        {
            Jugador MiJugador = null;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Jugadores WHERE IdJugador= @pidJugador";
                MiJugador = db.QueryFirstOrDefault<Jugador>(sqlQuery, new{pidJugador = idJugador});
            }
            return MiJugador;
        }

        public static List<Equipo> ListarEquipos()
        {
            List<Equipo> _MiEquipo = null;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Jugadores";
                _MiEquipo = db.Query<Equipos>(sqlQuery, new{pidEquipo = idEquipo}).ToList();
            }
            return _MiEquipo;
        }

        public static List<Jugador> ListarJugadores(int idEquipo)
        {
            List<Jugador> _MiJugador = null;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Jugadores WHERE idEquipo = @pidEquipo";
                _MiJugador = db.Query<Jugador>(sqlQuery).ToList();
            }
            return _MiJugador;
        }
    } 
}