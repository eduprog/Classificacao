
// Exemplo de uso
using Classificacao.Test;

public class Pessoa{
    public string Id { get; set;} =Guid.NewGuid().ToString();
    public string? Nome { get; set;}
    public ClassificacaoPessoa Classificacao { get; set;}
    //public Endereco? Endereco { get; set;} = new();
    }