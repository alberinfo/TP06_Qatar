using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System.IO;
using Microsoft.AspNetCore.Hosting;
using TP06_Qatar.Models;


namespace TP06_Qatar.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment Environment;

        public HomeController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.ListaDeEquipos = BD.ListarEquipos();
            return View();
        }

        public IActionResult VerDetalleEquipo(int IdEquipo){

            ViewBag.DatosEquipo = BD.VerInfoEquipo(IdEquipo);
            ViewBag.ListaJugadores = BD.ListarJugadores(IdEquipo);

            return View();
        }

        public IActionResult AgregarEquipo()
        {
            return View();
        }

        //Copas ganadas es string porque no se puede convertir a int desde el cshtml.
        [HttpPost]
        public IActionResult GuardarEquipo(string Nombre, IFormFile Escudo, IFormFile Camiseta, string Continente, string Copas)
        {
            int CopasGanadas = int.Parse(Copas);
            Equipo eq = new Equipo();
            eq.Nombre = Nombre;
            if(Escudo.Length > 0)
            {
                string wwwRootLocal = this.Environment.WebRootPath + '/' + Escudo.FileName;
                using(var stream = System.IO.File.Create(wwwRootLocal))
                {
                    Escudo.CopyToAsync(stream);
                }
                eq.Escudo = "/" + Escudo.FileName;
            }

            if(Camiseta.Length > 0)
            {
                string wwwRootLocal = this.Environment.WebRootPath + '/' + Camiseta.FileName;
                using(var stream = System.IO.File.Create(wwwRootLocal))
                {
                    (Camiseta).CopyToAsync(stream);
                }
                eq.Camiseta = "/" + Camiseta.FileName;
            }

            eq.Continente = Continente;
            eq.CopasGanadas = CopasGanadas;
            BD.AgregarEquipo(eq);

            return Index();
        }

        public IActionResult VerDetalleJugador(int IdJugador){  
            ViewBag.DatosJugador = BD.VerInfoJugador(IdJugador);

            return View();
        }

        public IActionResult AgregarJugador(int IdEquipo){
            ViewBag.IdEquipo = IdEquipo;
            return View("AgregarJugador");
        }

        [HttpPost] 
        public IActionResult GuardarJugador(string Nombre, string Nacimiento, IFormFile Foto, string Equipo)
        {
            DateTime FechaNacimiento = DateTime.Parse(Fecha);
            Jugador Jug = new Jugador();
            Jug.Nombre = Nombre;
            if(Foto.Length > 0)
            {
                string wwwRootLocal = this.Environment.WebRootPath + '/' + Foto.FileName;
                using(var stream = System.IO.File.Create(wwwRootLocal))
                {
                    Foto.CopyToAsync(stream);
                }
                eq.Foto = "/" + Foto.FileName;
            }
            eq.Equipo = Equipo;
            BD.AgregarEquipo(eq);
            
            return VerDetalleEquipo(Jug.IdEquipo);
        }

        public IActionResult EliminarJugador(int IdJugador, int IdEquipo){
            BD.EliminarJugador(IdJugador);
            return VerDetalleEquipo(IdEquipo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
