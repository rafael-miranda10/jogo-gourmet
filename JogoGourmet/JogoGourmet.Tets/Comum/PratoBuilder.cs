using JogoGourmet.Domain.Entidades;

namespace JogoGourmet.Tets.Comum
{
    public class PratoBuilder
    {
        private NoDeDecisao _direita;
        private NoDeDecisao _esquerda;
        private string _nomeDoPrato;

        public static PratoBuilder Novo()
        {
            var fake = FakerBuilder.Novo().Build();
            return new PratoBuilder
            {
                _direita = null,
                _esquerda = null,
                _nomeDoPrato = fake.Random.Word()
            };
        }

        public PratoBuilder ComNoDireita(NoDeDecisao direita)
        {
            _direita = direita;
            return this;
        }

        public PratoBuilder ComNoEsquerda(NoDeDecisao esquerda)
        {
            _esquerda = esquerda;
            return this;
        }

        public PratoBuilder ComNomeDoPrato(string nomeDoPrato)
        {
            _nomeDoPrato = nomeDoPrato;
            return this;
        }

        public Prato Build()
        {
            return new Prato(_esquerda, _direita, _nomeDoPrato);
        }
    }
}
