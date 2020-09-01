namespace JogoGourmet.Domain.Entidades
{
    public abstract class NoDeDecisao
    {
        private NoDeDecisao _filhoDaEsquerda;
        private NoDeDecisao _filhoDaDireita;
        private string _conteudo;

        public NoDeDecisao(NoDeDecisao filhoDaEsquerda, NoDeDecisao filhoDaDireita, string conteudo)
        {
            _filhoDaEsquerda = filhoDaEsquerda;
            _filhoDaDireita = filhoDaDireita;
            _conteudo = conteudo;
        }

        public NoDeDecisao RetornarFilhoDaEsquerda()
        {
            return _filhoDaEsquerda;
        }

        public void AdicionarFilhoDaEsquerda(NoDeDecisao filhoEsquerda)
        {
            _filhoDaEsquerda = filhoEsquerda;
        }

        public NoDeDecisao RetornarFilhoDaDireita()
        {
            return _filhoDaDireita;
        }

        public void AdicionarFilhoDaDireita(NoDeDecisao filhoDireita)
        {
            _filhoDaDireita = filhoDireita;
        }

        public string RetornarConteudo()
        {
            return _conteudo;
        }

        public void AdicionarConteudo(string conteudo)
        {
            _conteudo = conteudo;
        }

        public abstract bool Validar();
    }
}
