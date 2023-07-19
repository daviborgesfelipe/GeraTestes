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
            ServicoDisciplina servicoDisciplina)
        {
            this.repositorioDisciplina = _repositorioDisciplina;
            this.servicoDisciplina = servicoDisciplina;
        }

        public override void Excluir()
        {
            int id = tabelaDisciplina.ObtemIdSelecionado();

            Disciplina disciplinaSelecionada = repositorioDisciplina.SelecionarPorId(id);

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a disciplina?",
               "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoDisciplina.Excluir(disciplinaSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Disciplinas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarDisciplinas();
            }
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

        public override void Editar()
        {
            int id = tabelaDisciplina.ObtemIdSelecionado();

            Disciplina disciplinaSelecionada = repositorioDisciplina.SelecionarPorId(id);

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();

            tela.onGravarRegistro += servicoDisciplina.Editar;

            tela.ConfigurarDisciplina(disciplinaSelecionada);

            DialogResult resultado = tela.ShowDialog();

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
