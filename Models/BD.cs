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
                string sql = "INSERT INTO Jugadores (IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual) VALUES(@IdEquipo, @Nombre, @FechaNacimiento, @Foto, @EquipoActual)";
                int affectedRows = db.Execute<Jugador>(sqlQuery , new {idEquipo = jug.IdEquipo, Nombre = jug.Nombre, FechaNacimiento = Jug.FechaNacimiento, Foto = Jug.Foto, EquipoActual = Jug.EquipoActual});
            }
        }

        public static void EliminarJugador(int idJugador)
        {

        }

        public static Equipo VerInfoEquipo(int idEquipo)
        {

        }

        public static Jugador VerInfoJugador(int idJugador)
        {

        }

        public static List<Equipo> ListarEquipos()
        {

        }

        public static List<Jugador> ListarJugadores(int idEquipo)
        {

        }
    } 
}