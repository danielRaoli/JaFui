using System.ComponentModel.DataAnnotations;

namespace ViagemApi.Data.Dtos
{
    public class DestinoDto
    {
        public string? Name { get; set; }

        public string? FotoPerfil { get; set; }

        public string? FotoDetalhes { get; set; }

        public string? Descricao { get; set; }

        public string? Meta { get; set; }
    }
}
