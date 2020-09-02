using JogoGourmet.Domain.Entidades;

namespace JogoGourmet.Tets.Comum
{
    public class QuestaoBuilder
    {
        private NoDeDecisao _direita;
        private NoDeDecisao _esquerda;
        private string _descricao;

        public static QuestaoBuilder Novo()
        {
            var fake = FakerBuilder.Novo().Build();
            return new QuestaoBuilder
            {
                _direita = null,
                _esquerda = null,
                _descricao = fake.Random.Word() 
            };
        }

        public QuestaoBuilder ComNoDireita(NoDeDecisao direita)
        {
            _direita = direita;
            return this;
        }

        public QuestaoBuilder ComNoEsquerda(NoDeDecisao esquerda)
        {
            _esquerda = esquerda;
            return this;
        }

        public QuestaoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public Questao Build()
        {
            return new Questao(_esquerda, _direita, _descricao);
        }
    }
}
