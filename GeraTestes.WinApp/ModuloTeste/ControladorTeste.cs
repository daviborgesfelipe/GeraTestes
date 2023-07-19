using GeraTestes.Aplicacao.ModuloTeste;
using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloTeste;
using GeraTestes.WinApp.Compartilhado;

namespace GeraTestes.WinApp.ModuloTeste
{
    internal class ControladorTeste : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioTeste repositorioTeste;

        private ServicoTeste servicoTeste;

        private TabelaTesteControl tabelaTeste;

        public ControladorTeste(
            IRepositorioDisciplina repositorioDisciplina,
            IRepositorioTeste repositorioTeste,
            ServicoTeste servicoTeste
            )
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioTeste = repositorioTeste;
            this.servicoTeste = servicoTeste;
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTeste();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTeste == null)
                tabelaTeste = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTeste;
        }
        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(testes);

            TelaPrincipalForm.Instancia.AtualizarRodape(string.Format("Visualizando {0} teste{1}", testes.Count, testes.Count == 1 ? "" : "s"));
        }
    }
}
