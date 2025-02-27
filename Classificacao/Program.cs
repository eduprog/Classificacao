// Exemplo de uso
using Classificacao.Test;


internal class Program
{
    public static void Main(string[] args)
    {
        List<Pessoa> pessoas = [];
        List<Endereco> enderecos = [];

        //for (int i = 1; i <= 10; i++)
        //{
        //    var pessoa = new Pessoa
        //    {
        //        Nome = $"Pessoa {i}",
        //        Classificacao = default(ClassificacaoPessoa).GetRandomFlags()
        //    };

        //    var endereco = new Endereco
        //    {
        //        PessoaId = pessoa.Id,
        //        Nome = $"Endereço {i}",
        //        Tipo = default(TipoEndereco).GetRandomFlags()
        //    };
        //    // enderecos.Add(endereco);
        //    //pessoa.Endereco = new Endereco();
        //    // pessoa.Endereco.Id = endereco.Id;
        //    // pessoa.Endereco.Nome = endereco.Nome;
        //    // pessoa.Endereco.Tipo = endereco.Tipo;
        //    // pessoa.Endereco.PessoaId = pessoa.Id;
        //    pessoas.Add(pessoa);
        //}

        var pessoa1 = new Pessoa
        {
            Nome = $"Pessoa ",
            Classificacao = (ClassificacaoPessoa)128 //ClassificacaoPessoa.Cliente | ClassificacaoPessoa.Fornecedor
        };

        var pessoa2 = new Pessoa
        {
            Nome = $"Pessoa ",
            Classificacao = ClassificacaoPessoa.Cliente | ClassificacaoPessoa.Fornecedor
        };

        var pessoa3 = new Pessoa
        {
            Nome = $"Pessoa ",
            Classificacao = ClassificacaoPessoa.Cliente | ClassificacaoPessoa.Fornecedor | ClassificacaoPessoa.Transportadora
        };

        pessoas.Add(pessoa1);
        pessoas.Add(pessoa2);
        pessoas.Add(pessoa3);
        // Exibir as pessoas geradas
        foreach (var pessoa in pessoas)
        {
            var flagValida = ValorEhBitFlagValido<ClassificacaoPessoa>((int)pessoa.Classificacao);
            Console.ResetColor();
            Console.WriteLine($"{new string('-', 5)}|Pessoa {pessoa.Id} - {pessoa.Nome}|{new string('-', 5)}");
            //Console.WriteLine($"ID: {pessoa.Id}");
            //Console.WriteLine($"Nome: {pessoa.Nome}");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = flagValida
                ? ConsoleColor.Green
                : ConsoleColor.Red;

            Console.WriteLine(flagValida
                ? $"{pessoa.Classificacao.GetType().Name} é Válida"
                : $"{pessoa.Classificacao.GetType().Name} é Inválida");

            if (!flagValida)
            {
                Console.WriteLine();
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{new string('-', 20)}|List string's separado por vírgula|{new string('-', 20)}");
            Console.WriteLine($"Classificação: {pessoa.Classificacao} -  {pessoa.Classificacao.GetDescriptionFlags()}");



            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{new string('-', 20)}|List string's|{new string('-', 20)}");
            foreach (string classificacao in pessoa.Classificacao.GetDescriptionFlagList())
            {
                Console.WriteLine($"Classificação: {classificacao}");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{new string('-', 20)}|List ENUM's|{new string('-', 20)}");
            foreach (ClassificacaoPessoa classificacao in pessoa.Classificacao.GetActiveFlags())
            {
                Console.WriteLine($"Classificação: {classificacao}");
            }
            Console.ResetColor();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            // Console.WriteLine("ENDEREÇO:");
            // Console.WriteLine($"Nome: {pessoa.Endereco.Nome}");
            // Console.WriteLine($"Tipo: {pessoa.Endereco.Tipo.GetDescriptionFlags()}");
            // Console.WriteLine(new string('-', 40));
        }
        Console.ResetColor();
        Console.WriteLine("DIGITE QUALQUER TECLA PARA CONTINUAR...");
        Console.ReadKey();
    }

    private static bool ValorEhBitFlagValido<TFLAGENUM>(int valor) where TFLAGENUM : Enum
    {
        var todasAsFlags = Enum.GetValues(typeof(TFLAGENUM))
            .Cast<int>()
            .Aggregate((a, b) => a | b); // Soma todas as flags válidas
        var t = valor & todasAsFlags;
        return (valor & todasAsFlags) == valor; // Verifica se há bits inválidos
    }
}



