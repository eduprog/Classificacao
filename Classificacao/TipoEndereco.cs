namespace Classificacao.Test;
//[Flags]
public enum TipoEndereco
{
    Entrega = 1,        // 001
    Cobranca = 2,       // 010
    Alternativo = 4,    // 100
    Todos = 7           // 111 (Representa todos os tipos conhecidos até o momento)
}