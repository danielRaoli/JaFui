using System.ComponentModel.DataAnnotations;

namespace ViagemApi.Model;

public class Depoimento
{
    [Key]
    public int id { get; set; }
    public string name { get; private set; }
    public string depoimento { get; private set; }

    public string foto { get; private set; }

    public Depoimento(string name, string depoimento, string foto)
    {
        this.name = name;
        this.depoimento = depoimento;
        this.foto = foto;
    }
}
