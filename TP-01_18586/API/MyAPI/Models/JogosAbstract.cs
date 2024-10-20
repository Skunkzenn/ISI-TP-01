using System.ComponentModel.DataAnnotations;

public abstract class JogosAbstract
{
    [Key]  // Indica que esta propriedade é a chave primária
    public int ID { get; set; } //OK

    public string? Titulo { get; set; } //OK
    public double Vendas { get; set; }  // OK
    public double Preco { get; set; }   // OK
    public int Nota { get; set; }        // OK
    public bool Multiplataforma { get; set; } // OK
    public int MaximoJogadores { get; set; } // OK
    public string? Genero { get; set; } // OK
    public string? Fabricante { get; set; } //OK
    public string? Consola { get; set; } //OK
    public int AnoLancamento { get; set; } // OK
}
