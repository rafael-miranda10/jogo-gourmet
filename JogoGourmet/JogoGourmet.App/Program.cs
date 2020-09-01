using JogoGourmet.Domain.Entidades;
using JogoGourmet.Domain.Resources;
using System;
using System.Windows.Forms;

namespace JogoGourmet.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicio da árvore com as perguntas iniciais
            NoDeDecisao raiz = new Questao(null, null, Constantes.EhMassa);
            raiz.AdicionarFilhoDaDireita(new Prato(null, null, Constantes.EhLasanha));
            raiz.AdicionarFilhoDaEsquerda(new Prato(null, null, Constantes.EhBoloDeChocolate));

            DialogResult deveContinuar = DialogResult.OK;

            while (deveContinuar == DialogResult.OK)
            {
                deveContinuar = MessageBox.Show(Constantes.PratoQueGosta, Constantes.JogoGourmet, MessageBoxButtons.OKCancel);

                if (deveContinuar == DialogResult.OK)
                    // Iniando o jogo
                    raiz.ProximoNoDeDecisao(0, null);
            }
        }
    }
}
