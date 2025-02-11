
// Exemplo de uso
using Classificacao.Test;

public class Endereco{
    
    public string Id {get;set;} = Guid.NewGuid().ToString();
    public string? PessoaId {get;set;}
    public string? Nome { get; set;}
    public TipoEndereco Tipo { get; set;} = TipoEndereco.Todos;
}