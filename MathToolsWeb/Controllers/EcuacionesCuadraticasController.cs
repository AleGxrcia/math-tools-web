using MathToolsWeb.Models;
using MathToolsWeb.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MathToolsWeb.Controllers
{
    public class EcuacionesCuadraticasController : Controller
    {
        private readonly IServicioEcuaciones servicioEcuaciones;

        public EcuacionesCuadraticasController(IServicioEcuaciones servicioEcuaciones)
        {
            this.servicioEcuaciones = servicioEcuaciones;
        }

        public IActionResult Calcular()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(EcuacionCuadratica ecuacion)
        {
            if (!ModelState.IsValid)
            {
                return View(ecuacion);
            }

            var pasos = servicioEcuaciones.CalcularEcuacionCuadratica(ecuacion);
            ViewBag.Pasos = pasos;
            ViewBag.Ecuacion = ecuacion;

            return View(ecuacion);
        }
    }
}
