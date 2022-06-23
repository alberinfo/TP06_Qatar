using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using TP06_Qatar.Models;

namespace TP06_Qatar.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private IWebHostEnviroment Enviroment;

        public HomeController(IWebHostEnviroment enviroment)
        {
            Enviroment = enviroment
        }

        public IActionResult Index()
        {
            List<Equipos> ListTeams = new List<Equipos>();
            ListTeams = BD.ListarEquipos();

            ViewBag.ListaDeEquipos = ListTeams;
            return View();
        }

        public IActionResult VerDetalleEquipo(int IdEquipo){

            ViewBag.DatosEquipo = BD.VerInfoEquipo(IdEquipo);
            ViewBag.ListaJugadores = BD.ListarJugadores(IdEquipo);

            return View("DetalleEquipo");
        }

        public IActionResult VerDetalleJugador(int IdJugador){  
            ViewBag.DatosJugador = BD.VerDetalleJugador(IdJugador);

            return View("DetalleJugador");
        }

        public IActionResult AgregarJugador(int IdEquipo){
            ViewBag.IdEquipo = IdEquipo;
            return View("PlayerForm")
        }
        [HttpPost] 
        public IActionResult GuardarJugador(Jugador Jug, IFormFile ArchivoFoto){
            if(ArchivoFoto.Length>0)
            {
                string wwwRootLocal = this.Enviroment.ContentRoothPath + @"\wwwroot\"+(ArchivoFoto).FileName; 
                using(var stream = System.IO.File.Create(wwwRootLocal))
                {
                    (ArchivoFoto).CopyToAsync(stream);
                }
                Jug.Foto = ArchivoFoto.FileName;
            }
            BD.AgregarJugador(Jug);
            
            return RedirectToAction("VerDetalleEquipo", new {int Jug.IdEquipo});
        }

        public IActionResult EliminarJugador(int IdJugador, int IdEquipo){
            BD.EliminarJugador(idJugador);
            return RedirectToAction("VerDetalleEquipo", new {int IdEquipo});
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
