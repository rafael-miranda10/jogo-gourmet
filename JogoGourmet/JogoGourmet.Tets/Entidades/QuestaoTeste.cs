using JogoGourmet.Tets.Comum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JogoGourmet.Tets.Entidades
{
    [TestClass]
    public class QuestaoTeste
    {
        [TestInitialize]
        public void Iniciar()
        {
        }

        [TestMethod]
        public void DeveCriarUmaquestaoValida()
        {
            //arrange
            var questao = QuestaoBuilder.Novo().Build();

            //act

            var resultado = questao.Validar();

            //assert

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NaoDeveCriarUmaquestaoValida()
        {
            //arrange
            var descricaoInvalida = string.Empty;
            var questao = QuestaoBuilder.Novo().ComDescricao(descricaoInvalida).Build();

            //act

            var resultado = questao.Validar();

            //assert

            Assert.IsFalse(resultado);
        }
    }
}
