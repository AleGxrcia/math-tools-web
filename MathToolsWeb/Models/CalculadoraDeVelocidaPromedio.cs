using System.ComponentModel.DataAnnotations;

namespace MathToolsWeb.Models
{
    public class DatosVelocidad
    {
        [Required(ErrorMessage = "La velocidad inicial es requerida")]
        [Display(Name = "Velocidad Inicial:")]
        public double VelocidadInicial { get; set; }

        [Required(ErrorMessage = "La velocidad final es requerida")]
        [Display(Name = "Velocidad Final:")]
        public double VelocidadFinal { get; set; }

        [Required(ErrorMessage = "El tiempo es requerido")]
        [Display(Name = "Tiempo:")]
        public double Tiempo { get; set; }
    }
}
