using JogoGourmet.Domain.Entidades;
using JogoGourmet.Domain.Interfaces;
using JogoGourmet.Tets.Comum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JogoGourmet.Tets.Entidades
{
    [TestClass]
    public class PratoTeste
    {
        private Mock<IPrato> _pratoMock;

        [TestInitialize]
        public void Iniciar()
        {
            _pratoMock = new Mock<IPrato>();
            _pratoMock.Setup(x => x.AdicionarNoFilho(
                It.IsAny<int>(),
                It.IsAny<NoDeDecisao>(), 
                It.IsAny<string>(), 
                It.IsAny<string>()))
                .Verifiable();
        }

        [TestMethod]
        public void DeveCriarUmPratoValido()
        {
            //arrange
            var prato = PratoBuilder.Novo().Build();

            //act
            var resultado = prato.Validar();

            //assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NaoDeveCriarUmPratoValido()
        {
            //arrange
            var nomePrato = string.Empty;
            var prato = PratoBuilder.Novo().ComNomeDoPrato(nomePrato).Build();

            //act
            var resultado = prato.Validar();

            //assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void DeveAdicionarUmNoFilho()
        {
            //arrange
            var prato = PratoBuilder.Novo().Build();
            var noPai = QuestaoBuilder.Novo().Build();
            var ultimaOpacao = 1;

            //act
            prato.ProximoNoDeDecisao(ultimaOpacao, noPai);
            var resultado = noPai.RetornarFilhoDaEsquerda() != null;

            //assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NaoDeveAdicionarUmNoFilho()
        {
            //arrange
            var prato = PratoBuilder.Novo().Build();
            var noPai = QuestaoBuilder.Novo().Build();
            var ultimaOpacao = 1;

            //act
            prato.ProximoNoDeDecisao(ultimaOpacao, noPai);
            var resultado = noPai.RetornarFilhoDaEsquerda() != null;

            //assert
            Assert.IsFalse(resultado);
        }
    }
}
