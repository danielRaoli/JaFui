using System.ComponentModel.DataAnnotations;

namespace ViagemApi.ViewModels
{
    public class ViewCreateDestino
    {

        [Required(ErrorMessage = "this field is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public IFormFile FotoPerfil { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public IFormFile FotoDetalhes { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [MaxLength(100)]
        public string? Meta { get; set; }

        public string? Descricao { get; set; }

       

    }
}
