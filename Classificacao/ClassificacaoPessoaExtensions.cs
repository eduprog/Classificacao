// See https://aka.ms/new-console-template for more information
namespace Classificacao.Test;
public static class ClassificacaoPessoaExtensions
{
     private static readonly Random _random = new Random();
    public static List<string> GetClassificacoes(this ClassificacaoPessoa classificacao)
    {
        var classificacoes = new List<string>();

        // Itera sobre todos os valores do enum
        foreach (ClassificacaoPessoa value in Enum.GetValues(typeof(ClassificacaoPessoa)))
        {
            // Verifica se o valor atual está presente no campo 'classificacao'
            if (classificacao.HasFlag(value) && value != ClassificacaoPessoa.Pessoa)
            {
                classificacoes.Add(value.ToString());
            }
        }

        return classificacoes;
    }

    public static ClassificacaoPessoa GetRandomClassificacao()
    {
        var valores = Enum.GetValues(typeof(ClassificacaoPessoa));
        int randomValue = 0;

        // Gera um número aleatório combinando múltiplos valores do enum
        int count = _random.Next(1, valores.Length); // Número de classificações a incluir

        for (int i = 0; i < count; i++)
        {
            var randomFlag = (int)valores.GetValue(_random.Next(valores.Length));
            randomValue |= randomFlag; // Combina os valores usando OR bitwise
        }

        return (ClassificacaoPessoa)randomValue;
    }


    public static T GetRandomFlags<T>() where T : Enum
    {
        var valores = Enum.GetValues(typeof(T));
        int randomValue = 0;

        int count = _random.Next(1, valores.Length); // Número de flags a incluir

        for (int i = 0; i < count; i++)
        {
            var randomFlag = (int)valores.GetValue(_random.Next(valores.Length));
            randomValue |= randomFlag; // Aplica OR bitwise para combinar valores
        }

        return (T)(object)randomValue; // Converte para o tipo genérico
    }
}

