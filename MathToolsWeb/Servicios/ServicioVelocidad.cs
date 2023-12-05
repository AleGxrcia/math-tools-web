using MathToolsWeb.Models;
using System;
using System.Collections.Generic;

namespace MathToolsWeb.Servicios
{
    public interface IServicioVelocidad
    {
        double CalcularVelocidadPromedio(DatosVelocidad datos);
    }

    public class ServicioVelocidad : IServicioVelocidad
    {
        public double CalcularVelocidadPromedio(DatosVelocidad datos)
        {
            double velocidadPromedio = (datos.VelocidadInicial + datos.VelocidadFinal) / 2;
            return velocidadPromedio;
        }
    }
}
