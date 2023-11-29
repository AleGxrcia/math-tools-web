using System.ComponentModel.DataAnnotations;

namespace MathToolsWeb.Models
{
    public class EcuacionCuadratica
    {
        [Required(ErrorMessage = "El termino a es requerido")]
        [Display(Name = "a:")]
        public double A { get; set; }
        [Required(ErrorMessage = "El termino b es requerido")]
        [Display(Name = "b:")]
        public double B { get; set; }
        [Required(ErrorMessage = "El termino c es requerido")]
        [Display(Name = "c:")]
        public double C { get; set; }
    }
}
