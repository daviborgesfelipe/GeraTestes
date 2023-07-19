using GeraTestes.Dominio.ModuloTeste;

namespace GeraTestes.Aplicacao.ModuloTeste
{
    public class ServicoTeste
    {
        private IRepositorioTeste repositorioTeste;

        private ValidadorTeste validadorTeste;

        public ServicoTeste(
            IRepositorioTeste repositorioTeste,
            ValidadorTeste validadorTeste)
        {
            this.repositorioTeste = repositorioTeste;
            this.validadorTeste = validadorTeste;
        }
    }
}
