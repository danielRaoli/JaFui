using System.ComponentModel.DataAnnotations;

namespace ViagemApi.Data.Dtos
{
    public class DepoimentoDto
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O depoimento do usuário é obrigatório")]
        [MaxLength(300)]
        public string Depoimento { get; set; }

        [Required(ErrorMessage = "A foto do usuário é obrigatório")]
        public IFormFile  Foto{ get; set; }

    }
}
