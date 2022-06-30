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

            return View("DetalleEquipo");
        }

        public IActionResult AgregarJugador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarEquipo(Equipo eq, IFormFile ArchivoFoto)
        {
            if(ArchivoFoto.Length>0)
            {
                string wwwRootLocal = this.Environment.WebRootPath + @"\wwwroot\"+(ArchivoFoto).FileName; 
                using(var stream = System.IO.File.Create(wwwRootLocal))
                {
                    (ArchivoFoto).CopyToAsync(stream);
                }
                eq.Escudo = ArchivoFoto.FileName;
            }
            BD.AgregarEquipo(eq);
            return Index();
        }

        public IActionResult VerDetalleJugador(int IdJugador){  
            ViewBag.DatosJugador = BD.VerInfoJugador(IdJugador);

            return View("DetalleJugador");
        }

        public IActionResult AgregarJugador(int IdEquipo){
            ViewBag.IdEquipo = IdEquipo;
            return View("PlayerForm");
        }
        [HttpPost] 
        public IActionResult GuardarJugador(Jugador Jug, IFormFile ArchivoFoto){
            if(ArchivoFoto.Length>0)
            {
                string wwwRootLocal = this.Environment.WebRootPath + @"\wwwroot\"+(ArchivoFoto).FileName; 
                using(var stream = System.IO.File.Create(wwwRootLocal))
                {
                    (ArchivoFoto).CopyToAsync(stream);
                }
                Jug.Foto = ArchivoFoto.FileName;
            }
            BD.AgregarJugador(Jug);
            
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
