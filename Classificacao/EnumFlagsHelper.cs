namespace Classificacao.Test;
public static class EnumFlagsHelper
{

    private static readonly Random _random = new Random();
    public static List<string> GetFlags<T>(this T value) where T : Enum
    {
        var result = new List<string>();

        foreach (T enumValue in Enum.GetValues(typeof(T)))
        {
            if (value.HasFlag(enumValue) && Convert.ToInt32(enumValue) != 0) // Ignora "Nenhum" ou valores zerados
            {
                result.Add(enumValue.ToString());
            }
        }

        return result;
    }
    public static T GetRandomFlags2<T>(this T enumType) where T : Enum
    {
        // Obtém todos os valores do enum, excluindo o valor 0 (geralmente usado para representar "nenhum")
        var valores = Enum.GetValues(typeof(T)).Cast<T>().Where(v => !v.Equals(0)).ToArray();

        int randomValue = 0;

        // Define quantas flags serão combinadas
        int count = _random.Next(1, valores.Length + 1);

        for (int i = 0; i < count; i++)
        {
            T randomFlag;
            do
            {
                // Obtém uma flag aleatória
                randomFlag = valores[_random.Next(valores.Length)];
            } while ((Convert.ToInt32(randomValue) & Convert.ToInt32(randomFlag)) != 0); // Verifica se a flag já foi usada

            // Combina a flag aleatória ao valor final
            randomValue |= Convert.ToInt32(randomFlag);
        }

        // Retorna o valor final como o tipo de enum desejado
        return (T)(object)randomValue;
    }

    public static T GetRandomFlags<T>(this T enumType) where T : Enum
    {
        // Obtém todos os valores do enum, excluindo o valor 0 (geralmente usado para representar "nenhum")
        var valores = Enum.GetValues(typeof(T)).Cast<T>().Where(v => !v.Equals(0)).ToArray();

        int randomValue = 0;

        T randomFlag;
        do
        {
            // Obtém uma flag aleatória
            randomFlag = valores[_random.Next(valores.Length)];
        } while ((Convert.ToInt32(randomValue) & Convert.ToInt32(randomFlag)) != 0); // Verifica se a flag já foi usada

        // Combina a flag aleatória ao valor final
        randomValue |= Convert.ToInt32(randomFlag);

        // Retorna o valor final como o tipo de enum desejado
        return (T)(object)randomValue;
    }


    public static T GetFlagsRandom<T>() where T : Enum
    {
        var valores = Enum.GetValues(typeof(T)).Cast<int>().Where(v => v != 0).ToArray();
        int randomValue = 0;

        int count = _random.Next(1, valores.Length + 1); // Escolhe quantas flags combinar

        for (int i = 0; i < count; i++)
        {
            int randomFlag;
            do
            {
                randomFlag = valores[_random.Next(valores.Length)];
            } while ((randomValue & randomFlag) != 0); // Evita repetir a mesma flag

            randomValue |= randomFlag; // Adiciona a flag ao valor final
        }

        return (T)(object)randomValue; // Converte para o tipo genérico
    }

    public static string GetFlagsDescription<T>(T flags) where T : Enum
    {
        var selectedFlags = Enum.GetValues(typeof(T))
                                .Cast<T>()
                                .Where(flag => Convert.ToInt32(flags) != 0 && flags.HasFlag(flag) && Convert.ToInt32(flag) != 0)
                                .Select(flag => flag.ToString());

        return string.Join(", ", selectedFlags);
    }


    /// <summary>
    /// Obtém uma string contendo os nomes das flags ativadas em um enum do tipo Flags.
    /// </summary>
    /// <typeparam name="T">Tipo do enum (deve ser um Enum com atributo Flags).</typeparam>
    /// <param name="flags">O valor do enum cujas flags serão analisadas.</param>
    /// <returns>Uma string contendo os nomes das flags ativadas, separadas por vírgula.</returns>
    public static string GetDescriptionFlags<T>(this T flags) where T : Enum
    {
        // Obtém todos os valores do enum passado como parâmetro.
        var selectedFlags = Enum.GetValues(typeof(T))
            .Cast<T>() // Converte os valores obtidos para o tipo genérico T.
            .Where(flag =>
                Convert.ToInt32(flags) != 0 && // Garante que o valor de flags não é zero.
                flags.HasFlag(flag) && // Verifica se a flag específica está definida.
                Convert.ToInt32(flag) != 0) // Exclui o caso de uma flag que seja zero.
            .Select(flag => flag.ToString()); // Converte a flag para string.

        // Junta todas as flags ativadas em uma única string separada por vírgula.
        return string.Join(", ", selectedFlags);
    }

    /// <summary>
    /// Obtém uma lista de strings contendo os nomes das flags ativadas em um enum do tipo Flags.
    /// </summary>
    /// <typeparam name="T">Tipo do enum (deve ser um Enum com atributo Flags).</typeparam>
    /// <param name="flags">O valor do enum cujas flags serão analisadas.</param>
    /// <returns>Uma lista contendo os nomes das flags ativadas.</returns>
    public static List<string> GetDescriptionFlagList<T>(this T flags) where T : Enum
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>() // Converte os valores obtidos para o tipo genérico T.
            .Where(flag =>
                Convert.ToInt32(flags) != 0 && // Garante que o valor de flags não é zero.
                flags.HasFlag(flag) && // Verifica se a flag específica está definida.
                Convert.ToInt32(flag) != 0) // Exclui o caso de uma flag que seja zero.
            .Select(flag => flag.ToString()) // Converte a flag para string.
            .ToList(); // Retorna como uma lista de strings.
    }

}