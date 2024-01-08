using System.ComponentModel.DataAnnotations;

namespace ViagemApi.Data.Dtos
{
    public class DestinoDto
    {
    
        public string? Name { get; set; }
       
        public string? Foto { get; set; }

        public double Price { get; set; }
    }
}
