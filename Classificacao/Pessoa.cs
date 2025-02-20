
// Exemplo de uso
using Classificacao.Test;

public class Pessoa{
    public string Id { get; set;} =Guid.NewGuid().ToString();
    public string? Nome { get; set;}
    public ClassificacaoPessoa Classificacao { get; set;}
    //public Endereco? Endereco { get; set;} = new();
    //public bool IsCliente => Classificacao.HasFlag(ClassificacaoPessoa.Cliente);
    //public bool IsFornecedor => Classificacao.HasFlag(ClassificacaoPessoa.Fornecedor);
    //public bool IsTransportadora => Classificacao.HasFlag(ClassificacaoPessoa.Transportadora);
    //public bool IsFuncionario => Classificacao.HasFlag(ClassificacaoPessoa.Funcionario);
    //public bool IsVendedor => Classificacao.HasFlag(ClassificacaoPessoa.Vendedor);
    //public bool IsFabricante => Classificacao.HasFlag(ClassificacaoPessoa.Fabricante);
    //public bool IsRepresentante => Classificacao.HasFlag(ClassificacaoPessoa.Representante);


    public virtual Cliente Cliente { get; set; }

}



public record PessoaRespostaSimplificada
{

    //id, idalternativo, nome, apelido, documento, IsCliente, IsFornecedor
}


public record PessoaRespostaCompleta
{

}


//requisitar pessoa completa

//requisitar dados cliente pessoa 

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string PessoaId { get; set; }
}

//select * from pessoa
// left joint cliente 






