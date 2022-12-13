using back_end.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Genero: IValidatableObject
    {
        public int Id { get; set; }

  //    [PrimeraLetraMayuscula]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10)]
        public string Nombre { get; set; }

        [Range(18, 120)]
        public int Edad{ get; set; }
        [CreditCard]
        public string TarjetaDeCredito { get; set; }
        [Url]
        public string URL { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult(
                        "Debe ser mayúscula la primera letra",
                        new [] { nameof(Nombre) } );
                }
            }
        }
    }
}
