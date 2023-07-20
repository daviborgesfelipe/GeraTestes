﻿using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.Dominio.ModuloQuestao;
using GeraTestes.WinApp.Compartilhado;

namespace GeraTestes.WinApp.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        private Questao questao;
        public event GravarRegistroDelegate<Questao> onGravarRegistro;
        public TelaCadastroQuestaoForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarDisciplina(disciplinas);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa alternativa = new Alternativa();

            alternativa.Letra = questao.GerarLetraAlternativa();
            alternativa.Resposta = txtResposta.Text;

            questao.AdicionarAlternativa(alternativa);

            RecarregarAlternativas();

            txtResposta.Focus();
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            var alternativa = listAlternativas.SelectedItem as Alternativa;

            if (alternativa != null)
            {
                questao.RemoverAlternativa(alternativa);

                listAlternativas.Items.Remove(alternativa);

                RecarregarAlternativas();
            }
        }
        private void cmbDisciplinas_Changed(object sender, EventArgs e)
        {
            Disciplina disciplina = cmbDisciplinas.SelectedItem as Disciplina;

            if (disciplina != null)
                CarregarMaterias(disciplina.Materias);
        }
        private void CarregarMaterias(List<Materia> materias)
        {
            cmbMaterias.Items.Clear();

            foreach (var item in materias)
            {
                cmbMaterias.Items.Add(item);
            }
            cmbMaterias.DisplayMember = "Name";
        }
        private void CarregarDisciplina(List<Disciplina> disciplinas)
        {
            cmbDisciplinas.Items.Clear();
            foreach (var item in disciplinas)
            {
                cmbDisciplinas.Items.Add(item);
            }
            cmbDisciplinas.DisplayMember = "Nome";
        }
        private void RecarregarAlternativas()
        {
            listAlternativas.Items.Clear();

            int i = 0;
            foreach (var item in questao.Alternativas)
            {
                listAlternativas.Items.Add(item);

                if (item.Correta)
                    listAlternativas.SetItemChecked(i, true);

                i++;
            }
        }

        internal void ConfigurarQuestao(Questao questao)
        {
            this.questao = questao;

            txtId.Text = questao.Id.ToString();
            txtEnunciado.Text = questao.Enunciado;
            cmbDisciplinas.SelectedItem = questao.Materia?.Disciplina;
            cmbMaterias.SelectedItem = questao.Materia;
            chkJaUtilizada.Checked = questao.JaUtilizada;

            RecarregarAlternativas();
        }
        public Questao ObterQuestao()
        {
            questao.Id = Convert.ToInt32(txtId.Text);
            questao.Enunciado = txtEnunciado.Text;
            questao.Materia = (Materia)cmbMaterias.SelectedItem;
            questao.JaUtilizada = chkJaUtilizada.Checked;

            int i = 0;
            foreach (var item in listAlternativas.Items)
            {
                Alternativa a = (Alternativa)item;

                if (listAlternativas.GetItemChecked(i))
                    a.Correta = true;
                else
                    a.Correta = false;

                i++;
            }

            return questao;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.questao = ObterQuestao();

            Result resultado = onGravarRegistro(questao);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
