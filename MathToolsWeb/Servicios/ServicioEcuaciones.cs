using MathToolsWeb.Models;


namespace MathToolsWeb.Servicios
{
    public interface IServicioEcuaciones
    {
        List<string> CalcularEcuacionCuadratica(EcuacionCuadratica ecuacion);
        double Derivada(EcuacionCuadratica ecuacion);
        List<string> InterseccionX(EcuacionCuadratica ecuacion);
        string InterseccionY(EcuacionCuadratica ecuacion);
        (double, double) RectaTangente(EcuacionCuadratica ecuacion, double punto);
        string Vertice(EcuacionCuadratica ecuacion);
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
                pasos.Add("El discriminante es menor que cero, por lo tanto, la ecuación no tiene soluciones reales.");//La ecuación no tiene soluciones reales.
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

        public List<String> InterseccionX(EcuacionCuadratica ecuacion)
        {
            var interseccionesX = new List<string>();
            double discriminante = Math.Pow(ecuacion.B, 2) - 4 * (ecuacion.A * ecuacion.C);

            if (discriminante < 0)
            {
                // La ecuación no tiene intersecciones reales en el eje x.
                interseccionesX.Add("La ecuación no tiene intersecciones reales en el eje x.");
                return interseccionesX;
            }

                double x1 = (-ecuacion.B + Math.Sqrt(discriminante)) / (2 * ecuacion.A);
                double x2 = (-ecuacion.B - Math.Sqrt(discriminante)) / (2 * ecuacion.A);

                var InterseccionX1 = $"\\[ \\ x_1 = ({x1}, 0)\\]";
                var InterseccionX2 = $"\\[ \\ x_2 = ({x2}, 0)\\]";

            interseccionesX.Add(InterseccionX1);
            interseccionesX.Add(InterseccionX2);

            return interseccionesX;
        }

        public string InterseccionY(EcuacionCuadratica ecuacion)
        {

            double y = Math.Pow(0, 2) + 0 + (ecuacion.C);

            return $"\\[ \\ y = (0, {y})\\]";

        }

        public string Vertice(EcuacionCuadratica ecuacion)
        {
            double x = -ecuacion.B / (2 * ecuacion.A);
            double y = Math.Pow(x, 2) + (ecuacion.B * x) + (ecuacion.C);

            return $"\\[ \\ V = ({x}, {y})\\]";
        }

        public double Derivada(EcuacionCuadratica ecuacion)
        {
            // La derivada de una función cuadrática es 2Ax + B
            return 2 * ecuacion.A;
        }

        public (double, double) RectaTangente(EcuacionCuadratica ecuacion, double punto)
        {
            // Primero, calculamos la pendiente en el punto dado
            double pendiente = Derivada(ecuacion) * punto + ecuacion.B;

            // Luego, utilizamos la ecuación punto-pendiente para encontrar la ecuación de la recta tangente
            double b = ecuacion.A * Math.Pow(punto, 2) + ecuacion.B * punto + ecuacion.C - pendiente * punto;

            // Devolvemos la pendiente y b como una tupla
            return (pendiente, b);
        }





    }
}
