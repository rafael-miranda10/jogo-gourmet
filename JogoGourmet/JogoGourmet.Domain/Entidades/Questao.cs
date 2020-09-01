using System.Windows.Forms;

namespace JogoGourmet.Domain.Entidades
{
    public class Questao : NoDeDecisao
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
            if (Direita == null || Esquerda == null)
                return false;
            if (string.IsNullOrEmpty(Descricao))
                return false;
            return true;
        }

        public override int ObterResposta()
        {
            var mensagemPergunta = "O prato que você pensou " + this.RetornarConteudo() + "?";

            return (int)MessageBox.Show(mensagemPergunta, @"Jogo Gourmet", MessageBoxButtons.YesNo);
        }

        public override void ProximoNoDeDecisao(int ultimaOpcao, NoDeDecisao noPai)
        {
            var escolha = this.ObterResposta();

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
