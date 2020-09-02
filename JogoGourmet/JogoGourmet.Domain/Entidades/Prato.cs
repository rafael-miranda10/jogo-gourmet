using JogoGourmet.Domain.Interfaces;
using JogoGourmet.Domain.Resources;
using JogoGourmet.Domain.Utils;
using System.Windows.Forms;

namespace JogoGourmet.Domain.Entidades
{
    public class Prato : NoDeDecisao, IPrato
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
            if (string.IsNullOrEmpty(this.RetornarConteudo()))
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
                MessageBox.Show(Constantes.Acertei, Constantes.JogoGourmet);
            }
            else
            {
                var resposta = string.Empty;
                CaixaDeDialogo.Exibir(Constantes.JogoGourmet, Constantes.QualPratoQuePensou, ref resposta);

                var acao = string.Empty;
                CaixaDeDialogo.Exibir(Constantes.JogoGourmet, string.Format(Constantes.CompletarLacuna, resposta, this.RetornarConteudo()), ref acao);

                if (!ValidarAcaoEResposta(acao, resposta)) return;

                AdicionarNoFilho(ultimaOpcao, noPai, acao, resposta);
            }
        }

        private bool ValidarAcaoEResposta(string acao, string resposta)
        {
            if (string.IsNullOrEmpty(acao) || string.IsNullOrEmpty(resposta))
            {
                MessageBox.Show(Constantes.MSG_DadosInvalidos, Constantes.JogoGourmet);
                return false;
            }
            return true;
        }

        public void AdicionarNoFilho(int ultimaOpcao, NoDeDecisao noPai, string acao, string resposta)
        {
            var prato = NovoPrato(resposta);
            var questao = NovaQuestao(this, prato, acao);

            if (ultimaOpcao == (int)DialogResult.Yes)
            {
                noPai.AdicionarFilhoDaDireita(questao);
            }
            else
            {
                noPai.AdicionarFilhoDaEsquerda(questao);
            }
        }

        private Prato NovoPrato(string resposta)
        {
            return new Prato(null, null, resposta);
        }

        private Questao NovaQuestao(Prato esquerda, Prato direita, string nomeDoPrato)
        {
            return new Questao(esquerda, direita, nomeDoPrato);
        }
    }
}
