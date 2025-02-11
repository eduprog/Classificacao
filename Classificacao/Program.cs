
// Exemplo de uso
using Classificacao.Test;


List<Pessoa> pessoas = [];
List<Endereco> enderecos = [];

for (int i = 1; i <= 10; i++)
{
    var pessoa = new Pessoa
    {
        Nome = $"Pessoa {i}",
        Classificacao = default(ClassificacaoPessoa).GetRandomFlags()
    };

    var endereco = new Endereco
    {
        PessoaId = pessoa.Id,
        Nome = $"Endereço {i}",
        Tipo = default(TipoEndereco).GetRandomFlags()
    };
    // enderecos.Add(endereco);
    //pessoa.Endereco = new Endereco();
    // pessoa.Endereco.Id = endereco.Id;
    // pessoa.Endereco.Nome = endereco.Nome;
    // pessoa.Endereco.Tipo = endereco.Tipo;
    // pessoa.Endereco.PessoaId = pessoa.Id;
    pessoas.Add(pessoa);
}

// Exibir as pessoas geradas
foreach (var pessoa in pessoas)
{
    Console.WriteLine($"ID: {pessoa.Id}");
    Console.WriteLine($"Nome: {pessoa.Nome}");
    Console.WriteLine($"Classificação: {pessoa.Classificacao} -  {pessoa.Classificacao.GetDescriptionFlags()}");
    Console.WriteLine(new string('-', 40));
    // Console.WriteLine("ENDEREÇO:");
    // Console.WriteLine($"Nome: {pessoa.Endereco.Nome}");
    // Console.WriteLine($"Tipo: {pessoa.Endereco.Tipo.GetDescriptionFlags()}");
    // Console.WriteLine(new string('-', 40));
}
