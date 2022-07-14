using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public async void EscribirArchivo(IFormFile archivo, string path)
        {
            if(archivo.Length > 0)
            {
                using(Stream stream = new FileStream(path, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }
            }
            return;
        }

        public IActionResult Index()
        {
            if(!Directory.Exists(this.Environment.WebRootPath + "/img"))
            {
                Directory.CreateDirectory(this.Environment.WebRootPath + "/img"); //Create parent img directory
                //If parent img folder is not present then subfolders are not either
                Directory.CreateDirectory(this.Environment.WebRootPath + "/img/Escudos");
                Directory.CreateDirectory(this.Environment.WebRootPath + "/img/Camisetas");
                Directory.CreateDirectory(this.Environment.WebRootPath + "/img/Jugadores");
            }
            ViewBag.ListaEquipos = BD.ListarEquipos();
            return View();
        }

        public IActionResult VerDetalleEquipo(int IdEquipo){

            ViewBag.DatosEquipo = BD.VerInfoEquipo(IdEquipo);
            ViewBag.NombreContinente = BD.BuscarNombreContinente(IdEquipo);
            ViewBag.ListaJugadores = BD.ListarJugadores(IdEquipo);

            return View();
        }

        public IActionResult AgregarEquipo()
        {
            ViewBag.ListaContinentes = BD.ListarContinentes();
            ViewBag.ListaEquipos = BD.ListarEquipos();
            return View();
        }

        //Copas ganadas es string porque no se puede convertir a int desde el cshtml.
        [HttpPost]
        public IActionResult GuardarEquipo(Equipo eq, IFormFile ArchivoEscudo, IFormFile ArchivoCamiseta)
        {
            string wwwRootLocal =  "/img/Escudos/" + eq.Nombre.ToLower() + Path.GetExtension(ArchivoEscudo.FileName);
            EscribirArchivo(ArchivoEscudo, this.Environment.WebRootPath + wwwRootLocal);            
            eq.Escudo = wwwRootLocal;

            wwwRootLocal = "/img/Camisetas/" + eq.Nombre.ToLower() + Path.GetExtension(ArchivoCamiseta.FileName);
            EscribirArchivo(ArchivoCamiseta, this.Environment.WebRootPath + wwwRootLocal);            
            eq.Camiseta = wwwRootLocal;

            BD.AgregarEquipo(eq);

            //ViewBag.ListaEquipos = BD.ListarEquipos();
            //return View("Index");
            return Redirect(Url.Action("Index", "Home"));
        }

        public IActionResult VerDetalleJugador(int IdJugador){  
            ViewBag.DatosJugador = BD.VerInfoJugador(IdJugador);
            return View();
        }

        [HttpPost]
        public JsonResult VerDetalleJugadorAjax(int IdJugador){
            Jugador DatosJugador = BD.VerInfoJugador(IdJugador);
            return Json(DatosJugador);
        }

        public IActionResult AgregarJugador(int IdEquipo){
            ViewBag.IdEquipo = IdEquipo;
            ViewBag.ListaJugadores = BD.ListarJugadores(IdEquipo);
            return View();
        }

        [HttpPost] 
        public IActionResult GuardarJugador(Jugador Jug, IFormFile Foto)
        {
            Jug.EquipoActual = BD.BuscarNombreEquipo(Jug.IdEquipo);

            string wwwRootLocal = "/img/Jugadores/" + Jug.EquipoActual.ToLower() + Jug.NumCamiseta.ToString() + Path.GetExtension(Foto.FileName);
            EscribirArchivo(Foto, this.Environment.WebRootPath + wwwRootLocal);
            Jug.Foto = wwwRootLocal;

            BD.AgregarJugador(Jug);
            
            return Redirect(Url.Action("VerDetalleEquipo", "Home", new {IdEquipo = Jug.IdEquipo}));
        }

        public IActionResult EliminarJugador(int IdJugador, int IdEquipo){
            BD.EliminarJugador(IdJugador);
            return Redirect(Url.Action("VerDetalleEquipo", "Home", new {IdEquipo = IdEquipo}));
            //return VerDetalleEquipo(IdEquipo);
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
