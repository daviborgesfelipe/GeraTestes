using GeraTestes.Aplicacao.ModuloMateria;
using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.WinApp.Compartilhado;
using GeraTestes.WinApp.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraTestes.WinApp.ModuloMateria
{
    internal class ControladorMateria : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;

        private ServicoMateria servicoMateria;

        private TabelaMateriasControl tabelaMaterias;

        public ControladorMateria(
            IRepositorioDisciplina repositorioDisciplina,
            IRepositorioMateria repositorioMateria,
            ServicoMateria servicoMateria
            )
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.servicoMateria = servicoMateria;
        }

        public override void Excluir()
        {
            int id = tabelaMaterias.ObtemIdSelecionado();

            Materia materiaSelecionada = repositorioMateria.SelecionarPorId(id);

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Exclusão de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a matéria?",
               "Exclusão de Materias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoMateria.Excluir(materiaSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarMaterias();
            }
        }

        public override void Inserir()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm(disciplinas);

            tela.onGravarRegistro += servicoMateria.Inserir;

            tela.ConfigurarMateria(new Materia());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMaterias();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaMaterias == null)
                tabelaMaterias = new TabelaMateriasControl();

            CarregarMaterias();

            return tabelaMaterias;
        }
        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMaterias.AtualizarRegistros(materias);
            mensagemRodape = string.Format("Visualizando {0} matéria{1}", materias.Count, materias.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
