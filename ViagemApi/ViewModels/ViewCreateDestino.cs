using System.ComponentModel.DataAnnotations;

namespace ViagemApi.ViewModels
{
    public class ViewCreateDestino
    {

        [Required(ErrorMessage = "this field is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public IFormFile Foto { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [Range(50.00, 10000, ErrorMessage = "The price must be between 50,00 and 10.000,00")]
        public double Price { get; set; }
    }
}
