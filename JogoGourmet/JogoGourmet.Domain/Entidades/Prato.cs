using JogoGourmet.Domain.Resources;
using JogoGourmet.Domain.Utils;
using System.Windows.Forms;

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

        public override int ObterResposta()
        {
            var mensagemPergunta = string.Format(Constantes.OhPratoQuePensou, this.RetornarConteudo());

            return (int)MessageBox.Show(mensagemPergunta, Constantes.JogoGourmet, MessageBoxButtons.YesNo);
        }

        public override void ProximoNoDeDecisao(int ultimaOpcao, NoDeDecisao noPai)
        {
            var escolha = this.ObterResposta();

            if (escolha == (int)DialogResult.Yes)
            {
                MessageBox.Show(@"Acertei!!!", @"Jogo Gourmet");
            }
            else
            {
                var resposta = string.Empty;
                CaixaDeDialogo.Exibir(@"Jogo Gourmet", "Qual o prato que você pensou?", ref resposta);

                var acao = "";
                CaixaDeDialogo.Exibir(@"Jogo Gourmet", "E " + resposta + " é _____ mas " + this.RetornarConteudo() + " não é...", ref acao);

                if (string.IsNullOrEmpty(acao) || string.IsNullOrEmpty(resposta))
                {
                    var message = "Por gentileza, você de informar os dados :D !\n"
                                           + "Vamos voltar para o início sem cadastrar seu prato.";
                    MessageBox.Show(message, @"Jogo Gourmet");
                    return;
                }

                var novoPrato = new Prato(null, null, resposta);

                if (ultimaOpcao == (int)DialogResult.Yes)
                {
                    noPai.AdicionarFilhoDaDireita(new Questao(this, novoPrato, acao));
                }
                else
                {
                    noPai.AdicionarFilhoDaEsquerda(new Questao(this, novoPrato, acao));
                }
            }
        }
    }
}
