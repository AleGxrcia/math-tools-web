using MathToolsWeb.Models;
using MathToolsWeb.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace MathToolsWeb.Controllers
{
    public class GraficarFuncionesController : Controller
    {
        private readonly IServicioEcuaciones servicioEcuaciones;

        public GraficarFuncionesController(IServicioEcuaciones servicioEcuaciones)
        {
            this.servicioEcuaciones = servicioEcuaciones;
        }

        [HttpGet]
        public IActionResult GraficarParabola()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Graficar(EcuacionCuadratica ecuacion)
        {
            var punto = 2;

            if (!ModelState.IsValid)
            {
                return View();
            }

            var interseccionX = servicioEcuaciones.InterseccionX(ecuacion);
            var interseccionY = servicioEcuaciones.InterseccionY(ecuacion);
            var vertice = servicioEcuaciones.Vertice(ecuacion);
            var rectaTan = servicioEcuaciones.RectaTangente(ecuacion, punto);

            ViewBag.InterseccionX = interseccionX;
            ViewBag.InterseccionY = interseccionY;
            ViewBag.Vertice = vertice;
            ViewBag.Ecuacion = ecuacion;
            ViewBag.Pendiente = rectaTan.Item1;
            ViewBag.PuntoPendiente = rectaTan.Item2;

            return View("ResultadosParabola", ecuacion);
        }

    }
}
