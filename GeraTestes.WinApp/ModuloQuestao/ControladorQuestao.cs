using GeraTestes.Aplicacao.ModuloQuestao;
using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloQuestao;
using GeraTestes.WinApp.Compartilhado;

namespace GeraTestes.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioQuestao repositorioQuestao;

        private ServicoQuestao servicoQuestao;

        private TabelaQuestaoControl tabelaQuestao;

        public ControladorQuestao(
            IRepositorioQuestao repositorioQuestao,
            IRepositorioDisciplina repositorioDisciplina,
            ServicoQuestao servicoQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
            this.servicoQuestao = servicoQuestao;
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxQuestao();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia.AtualizarRodape(string.Format("Visualizando {0} quest{1}", questoes.Count, questoes.Count == 1 ? "ão" : "ões"));
        }
        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }
    }
}
