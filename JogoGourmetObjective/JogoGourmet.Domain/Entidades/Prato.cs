namespace JogoGourmet.Domain.Entidades
{
    public class Prato : NoDeDecisao
    {
        public NoDeDecisao Direita { get; private set; }
        public NoDeDecisao Esquerda { get; private set; }
        public string NomeDoPrato { get; private set; }

        public Prato(NoDeDecisao esquerda, NoDeDecisao direita, string nomeDoPrato)
            : base(esquerda, direita, nomeDoPrato)
        {
        }

        public void AdicionarDireita(NoDeDecisao direita)
        {
            Direita = direita;
        }

        public void AdicionarEsquerda(NoDeDecisao esquerda)
        {
            Esquerda = esquerda;
        }

        public void AdicionarNomeDoPrato(string nomeDoPrato)
        {
            NomeDoPrato = nomeDoPrato;
        }

        public override bool Validar()
        {
            if (Direita == null || Esquerda == null)
                return false;
            if (string.IsNullOrEmpty(NomeDoPrato))
                return false;
            return true;
        }
    }
}
