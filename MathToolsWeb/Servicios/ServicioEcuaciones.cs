using MathToolsWeb.Models;

namespace MathToolsWeb.Servicios
{
    public interface IServicioEcuaciones
    {
        List<string> CalcularEcuacionCuadratica(EcuacionCuadratica ecuacion);
    }

    public class ServicioEcuaciones : IServicioEcuaciones
    {
        public List<string> CalcularEcuacionCuadratica(EcuacionCuadratica ecuacion)
        {
            var pasos = new List<string>();

            var paso1 = $"\\[ \\ x = {{-({ecuacion.B}) \\pm \\sqrt{{({ecuacion.B})^2-4({ecuacion.A})({ecuacion.C})}} \\over 2({ecuacion.A})}}.\\]";
            pasos.Add(paso1);

            var b = ecuacion.B < 0 ? $"{-ecuacion.B}" : $"{ecuacion.B}";
            var paso2 = $"\\[ \\ x = {{-{b} \\pm \\sqrt{{{Math.Pow(ecuacion.B, 2)}-4*{ecuacion.A}*{ecuacion.C}}} \\over 2*{ecuacion.A}}}.\\]";
            pasos.Add(paso2);

            var paso3 = $"\\[ \\ x = {{-{b} \\pm \\sqrt{{{Math.Pow(ecuacion.B, 2) - 4 * ecuacion.A * ecuacion.C}}} \\over {2 * ecuacion.A}}}.\\]";
            pasos.Add(paso3);

            var discriminante = Math.Pow(ecuacion.B, 2) - 4 * ecuacion.A * ecuacion.C;

            if (discriminante < 0)
            {
                pasos.Add("El discriminante es menor que cero, por lo tanto, la ecuación no tiene soluciones reales.");
                return pasos;
            }

            var raiz = Math.Sqrt(discriminante);
            var paso4 = $"\\[ \\ x = {{-{b} \\pm {raiz} \\over {2 * ecuacion.A}}}.\\]";
            pasos.Add(paso4);

            var x1 = (-ecuacion.B + raiz) / (2 * ecuacion.A);
            var x2 = (-ecuacion.B - raiz) / (2 * ecuacion.A);

            var paso5 = $"\\[ \\ x_1 = {x1}.\\]";
            var paso6 = $"\\[ \\ x_2 = {x2}.\\]";

            pasos.Add(paso5);
            pasos.Add(paso6);

            return pasos;

           
        }
    }
}
