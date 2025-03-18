using System.Text;

namespace Classificacao.Test;
public static class EnumFlagsHelper
{

    private static readonly Random _random = new Random();

    #region MyRegion
    //public static List<string> GetFlags<T>(this T value) where T : Enum
    //{
    //    var result = new List<string>();

    //    foreach (T enumValue in Enum.GetValues(typeof(T)))
    //    {
    //        if (value.HasFlag(enumValue) && Convert.ToInt32(enumValue) != 0) // Ignora "Nenhum" ou valores zerados
    //        {
    //            result.Add(enumValue.ToString());
    //        }
    //    }

    //    return result;
    //}
    //public static T GetRandomFlags2<T>(this T enumType) where T : Enum
    //{
    //    // Obtém todos os valores do enum, excluindo o valor 0 (geralmente usado para representar "nenhum")
    //    var valores = Enum.GetValues(typeof(T)).Cast<T>().Where(v => !v.Equals(0)).ToArray();

    //    int randomValue = 0;

    //    // Define quantas flags serão combinadas
    //    int count = _random.Next(1, valores.Length + 1);

    //    for (int i = 0; i < count; i++)
    //    {
    //        T randomFlag;
    //        do
    //        {
    //            // Obtém uma flag aleatória
    //            randomFlag = valores[_random.Next(valores.Length)];
    //        } while ((Convert.ToInt32(randomValue) & Convert.ToInt32(randomFlag)) != 0); // Verifica se a flag já foi usada

    //        // Combina a flag aleatória ao valor final
    //        randomValue |= Convert.ToInt32(randomFlag);
    //    }

    //    // Retorna o valor final como o tipo de enum desejado
    //    return (T)(object)randomValue;
    //}

    //public static T GetRandomFlags<T>(this T enumType) where T : Enum
    //{
    //    // Obtém todos os valores do enum, excluindo o valor 0 (geralmente usado para representar "nenhum")
    //    var valores = Enum.GetValues(typeof(T)).Cast<T>().Where(v => !v.Equals(0)).ToArray();

    //    int randomValue = 0;

    //    T randomFlag;
    //    do
    //    {
    //        // Obtém uma flag aleatória
    //        randomFlag = valores[_random.Next(valores.Length)];
    //    } while ((Convert.ToInt32(randomValue) & Convert.ToInt32(randomFlag)) != 0); // Verifica se a flag já foi usada

    //    // Combina a flag aleatória ao valor final
    //    randomValue |= Convert.ToInt32(randomFlag);

    //    // Retorna o valor final como o tipo de enum desejado
    //    return (T)(object)randomValue;
    //}


    //public static T GetFlagsRandom<T>() where T : Enum
    //{
    //    var valores = Enum.GetValues(typeof(T)).Cast<int>().Where(v => v != 0).ToArray();
    //    int randomValue = 0;

    //    int count = _random.Next(1, valores.Length + 1); // Escolhe quantas flags combinar

    //    for (int i = 0; i < count; i++)
    //    {
    //        int randomFlag;
    //        do
    //        {
    //            randomFlag = valores[_random.Next(valores.Length)];
    //        } while ((randomValue & randomFlag) != 0); // Evita repetir a mesma flag

    //        randomValue |= randomFlag; // Adiciona a flag ao valor final
    //    }

    //    return (T)(object)randomValue; // Converte para o tipo genérico
    //}

    //public static string GetFlagsDescription<T>(T flags) where T : Enum
    //{
    //    var selectedFlags = Enum.GetValues(typeof(T))
    //                            .Cast<T>()
    //                            .Where(flag => Convert.ToInt32(flags) != 0 && flags.HasFlag(flag) && Convert.ToInt32(flag) != 0)
    //                            .Select(flag => flag.ToString());

    //    return string.Join(", ", selectedFlags);
    //}


    ///// <summary>
    ///// Obtém uma string contendo os nomes das flags ativadas em um enum do tipo Flags.
    ///// </summary>
    ///// <typeparam name="T">Tipo do enum (deve ser um Enum com atributo Flags).</typeparam>
    ///// <param name="flags">O valor do enum cujas flags serão analisadas.</param>
    ///// <returns>Uma string contendo os nomes das flags ativadas, separadas por vírgula.</returns>
    //public static string GetDescriptionFlagsToString<T>(this T flags) where T : Enum
    //{
    //    // Obtém todos os valores do enum passado como parâmetro.
    //    var selectedFlags = Enum.GetValues(typeof(T))
    //        .Cast<T>() // Converte os valores obtidos para o tipo genérico T.
    //        .Where(flag =>
    //            Convert.ToInt32(flags) != 0 && // Garante que o valor de flags não é zero.
    //            flags.HasFlag(flag) && // Verifica se a flag específica está definida.
    //            Convert.ToInt32(flag) != 0) // Exclui o caso de uma flag que seja zero.
    //        .Select(flag => flag.ToString()); // Converte a flag para string.

    //    // Junta todas as flags ativadas em uma única string separada por vírgula.
    //    return string.Join(", ", selectedFlags);
    //} 
    #endregion



    /// <summary>
    /// Obtém uma string contendo os nomes das flags ativadas em um enum do tipo Flags.
    /// </summary>
    /// <typeparam name="T">Tipo do enum (deve ser um Enum com atributo Flags).</typeparam>
    /// <param name="flags">O valor do enum cujas flags serão analisadas.</param>
    /// <returns>Uma string contendo os nomes das flags ativadas, separadas por vírgula.</returns>
    public static string GetDescriptionFlagsToString<T>(this T flags) where T : Enum
    {
        // Obtém um array com todos os valores possíveis do enum.
        Array enumValues = Enum.GetValues(typeof(T));

        // StringBuilder para armazenar o resultado da concatenação.
        StringBuilder result = new StringBuilder();

        // Converte o valor do enum passado para inteiro.
        int flagsValue = Convert.ToInt32(flags);

        // Verifica se flags não é zero, pois zero pode indicar "nenhuma flag definida".
        if (flagsValue == 0)
        {
            return string.Empty;
        }

        // Itera sobre todos os valores do enum.
        foreach (object value in enumValues)
        {
            // Converte o valor atual para inteiro.
            int enumIntValue = Convert.ToInt32(value);

            // Se o valor do enum for zero, ignora (para evitar adicionar "Nenhuma" ou valores inválidos).
            if (enumIntValue == 0)
            {
                continue;
            }
            //Cliente = 1,          // 0001
            //Fornecedor = 2,       // 0010
            //Transportadora = 4,   // 0100
            //Funcionario = 8,      // 1000
            //Vendedor = 16,        // 10000
            //Fabricante = 32,      // 100000
            //Representante = 64,   // 1000000

            var flagsValue_enumINtValue = (flagsValue & enumIntValue);
            // Verifica se a flag está definida no valor passado.
            if (flagsValue_enumINtValue == enumIntValue)
            {
                // Se já houver algum valor no StringBuilder, adiciona uma vírgula antes.
                if (result.Length > 0)
                {
                    result.Append(", ");
                }

                // Adiciona o nome da flag ao resultado.
                result.Append(value.ToString());
            }
        }

        // Retorna o resultado como string.
        return result.ToString();
    }


    /// <summary>
    /// Obtém uma lista contendo as flags ativadas em um enum do tipo Flags.
    /// </summary>
    /// <typeparam name="T">Tipo do enum (deve ser um Enum com atributo Flags).</typeparam>
    /// <param name="flags">O valor do enum cujas flags serão analisadas.</param>
    /// <returns>Uma lista contendo as flags ativadas.</returns>
    public static List<T> GetActiveFlags<T>(this T flags) where T : Enum
    {
        var activeFlags = new List<T>();

        // Obtém todos os valores do enum e converte para inteiro
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            int enumIntValue = Convert.ToInt32(value);
            int flagsValue = Convert.ToInt32(flags);

            // Ignora o valor 0 (nenhuma flag definida)
            if (enumIntValue == 0)
            {
                continue;
            }

            // Verifica se a flag está definida no valor passado
            if ((flagsValue & enumIntValue) == enumIntValue)
            {
                activeFlags.Add(value);
            }
        }

        return activeFlags;
    }




    /// <summary>
    /// Obtém uma lista de strings contendo os nomes das flags ativadas em um enum do tipo Flags.
    /// </summary>
    /// <typeparam name="T">Tipo do enum (deve ser um Enum com atributo Flags).</typeparam>
    /// <param name="flags">O valor do enum cujas flags serão analisadas.</param>
    /// <returns>Uma lista contendo os nomes das flags ativadas.</returns>
    public static List<string> GetDescriptionFlagToList<T>(this T flags) where T : Enum
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

    /// <summary>
    /// Verifica se um valor inteiro representa uma combinação válida de flags de um enum com o atributo [Flags].
    /// </summary>
    /// <typeparam name="T">O tipo do enum (deve ser um Enum com atributo Flags).</typeparam>
    /// <param name="valor">O valor inteiro a ser validado.</param>
    /// <returns>True se o valor contiver apenas flags válidas do enum, caso contrário, False.</returns>
    public static bool BitFlagIsValid<T>(this T valor) where T : Enum
    {
        int valorInt = Convert.ToInt32(valor);

        // Obtém todas as flags válidas do enum e realiza um OR bitwise para consolidar todas em um único valor
        int todasAsFlags = Enum.GetValues(typeof(T)).Cast<int>().Aggregate((a, b) => a | b);

        // Verifica se o valor contém apenas flags válidas
        return (valorInt & todasAsFlags) == valorInt;
    }



}