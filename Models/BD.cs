using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace TP06_Qatar.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=DESKTOP-78D5FAT\SQLExpress;DataBase=Qatar;Trusted_Connection=True";

        public static void AgregarJugador(Jugador jug)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "INSERT INTO Jugadores (IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual, NumCamiseta) VALUES(@IdEquipo, @Nombre, @FechaNacimientoDateTime, @Foto, @EquipoActual, @NumCamiseta)";
                //int affectedRows = db.Execute(sqlQuery , new {IdEquipo = jug.IdEquipo, Nombre = jug.Nombre, FechaNacimiento = jug.FechaNacimiento, Foto = jug.Foto, EquipoActual = jug.EquipoActual});
                int affectedRows = db.Execute(sqlQuery, jug);
            }
        }

        public static void AgregarEquipo(Equipo eq)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "INSERT INTO Equipos (Nombre, Escudo, Camiseta, IdContinente, CopasGanadas) VALUES(@Nombre, @Escudo, @Camiseta, @IdContinente, @CopasGanadas)";
                //int affectedRows = db.Execute(sqlQuery, new {Nombre = eq.Nombre, Escudo = eq.Escudo, Camiseta = eq.Camiseta, IdContinente = eq.Continente, CopasGanadas = eq.CopasGanadas});
                int affectedRows = db.Execute(sqlQuery, eq);
            }
        }

        public static void EliminarJugador(int idJugador)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "DELETE FROM Jugadores WHERE IdJugador = @pidJugador";
                int affectedRows = db.Execute(sqlQuery , new {pidJugador = idJugador});
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
                string sqlQuery = "SELECT * FROM Equipos";
                _MiEquipo = db.Query<Equipo>(sqlQuery).ToList();
            }
            return _MiEquipo;
        }

        public static string BuscarNombreEquipo(int id)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT Nombre FROM Equipos WHERE IdEquipo = @pId";
                return db.QueryFirstOrDefault<string>(sqlQuery, new {pId = id});
            }
        }

        public static int BuscarIdEquipo(string nombre)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT IdEquipo FROM Equipos WHERE Nombre = @pNombre";
                return db.QueryFirstOrDefault<int>(sqlQuery, new {pNombre = nombre});
            }
        }

        public static List<Jugador> ListarJugadores(int idEquipo)
        {
            List<Jugador> _MiJugador = null;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Jugadores WHERE idEquipo = @pidEquipo";
                _MiJugador = db.Query<Jugador>(sqlQuery, new {pidEquipo = idEquipo}).ToList();
            }
            return _MiJugador;
        }

        public static List<Continente> ListarContinentes()
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Continentes";
                return db.Query<Continente>(sqlQuery).ToList();
            }
        }

        public static int BuscarIdContinente(string nombre)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT IdContinente FROM Continentes WHERE Nombre = @pNombre";
                return db.QueryFirstOrDefault<int>(sqlQuery, new {pNombre = nombre.ToLower()});
            }
        }

        public static string BuscarNombreContinente(int id)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT Nombre FROM Continentes WHERE IdContinente = @pIdContinente";
                return db.QueryFirstOrDefault<string>(sqlQuery, new {pIdContinente = id});
            }
        }
    }
}