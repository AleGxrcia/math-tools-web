using MathToolsWeb.Models;
using MathToolsWeb.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace MathToolsWeb.Controllers
{
    public class VelocidadPromedioController : Controller
    {
        private readonly IServicioVelocidad servicioVelocidad;

        public VelocidadPromedioController(IServicioVelocidad servicioVelocidad)
        {
            this.servicioVelocidad = servicioVelocidad;
        }

        public IActionResult Calcular()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(DatosVelocidad datos)
        {
            if (!ModelState.IsValid)
            {
                return View(datos);
            }

            var resultado = servicioVelocidad.CalcularVelocidadPromedio(datos);
            ViewBag.Resultado = resultado;
            ViewBag.Datos = datos;

            return View(datos);
        }
    }
}
