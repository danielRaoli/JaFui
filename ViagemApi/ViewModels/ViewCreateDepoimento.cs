using System.ComponentModel.DataAnnotations;

namespace ViagemApi.ViewModels
{
    public class ViewCreateDepoimento
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Depoimento { get; set; }

        public IFormFile Foto { get; set; }

    }
}
