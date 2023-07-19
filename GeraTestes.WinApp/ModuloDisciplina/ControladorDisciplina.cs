using GeraTestes.Aplicacao.ModuloDisciplina;
using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.WinApp.Compartilhado;
using System.Runtime.CompilerServices;

namespace GeraTestes.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private TabelaDisciplinaControl tabelaDisciplina;
        private IRepositorioDisciplina repositorioDisciplina;
        private ServicoDisciplina servicoDisciplina;
        public ControladorDisciplina(
            IRepositorioDisciplina _repositorioDisciplina,
            ServicoDisciplina _servicoDisciplina)
        {
            this.repositorioDisciplina = _repositorioDisciplina;
            this.servicoDisciplina = _servicoDisciplina;
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            TelaCadastroDisciplinaForm telaCadastroDisciplina = new TelaCadastroDisciplinaForm();
            telaCadastroDisciplina.onGravarRegistro += servicoDisciplina.Inserir;
            telaCadastroDisciplina.ConfigurarDisciplina(new Disciplina());

            DialogResult resultado = telaCadastroDisciplina.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxDisciplina();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplinas();

            return tabelaDisciplina;
        }

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(disciplinas);
            mensagemRodape = string.Format("Visualizando {0} disciplina{1}", disciplinas.Count, disciplinas.Count == 1 ? "" : "s");

            TelaPrincipalForm.InstanciaTelaPrincipal.AtualizarRodape(mensagemRodape);
        }
    }
}
