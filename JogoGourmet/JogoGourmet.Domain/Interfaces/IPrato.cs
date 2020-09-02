using JogoGourmet.Domain.Entidades;

namespace JogoGourmet.Domain.Interfaces
{
    public interface IPrato
    {
        void AdicionarNoFilho(int ultimaOpcao, NoDeDecisao noPai, string acao, string resposta);
    }
}
