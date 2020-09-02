using JogoGourmet.Domain.Interfaces;
using JogoGourmet.Domain.Resources;
using System.Windows.Forms;

namespace JogoGourmet.Domain.Entidades
{
    public class Questao : NoDeDecisao, IQuestao
    {
        public NoDeDecisao Direita { get; private set; }
        public NoDeDecisao Esquerda { get; private set; }
        public string Descricao { get; private set; }

        public Questao(NoDeDecisao esquerda, NoDeDecisao direita, string nomeDoPrato)
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

        public void AdicionarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.RetornarConteudo()))
                return false;
            return true;
        }

        public override int ObterResposta()
        {
            return (int)MessageBox.Show(string.Format(Constantes.PerguntaOhPratoQuePensou, this.RetornarConteudo()),
                Constantes.JogoGourmet, MessageBoxButtons.YesNo);
        }

        public override void ProximoNoDeDecisao(int ultimaOpcao, NoDeDecisao noPai)
        {
            RetornarNoFilho(this.ObterResposta());
        }

        public void RetornarNoFilho(int escolha)
        {
            if (escolha == (int)DialogResult.Yes)
            {
                this.RetornarFilhoDaDireita().ProximoNoDeDecisao(escolha, this);
            }
            else
            {
                this.RetornarFilhoDaEsquerda().ProximoNoDeDecisao(escolha, this);
            }
        }
    }
}
