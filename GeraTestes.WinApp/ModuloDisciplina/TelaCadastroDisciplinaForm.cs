using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.WinApp.Compartilhado;

namespace GeraTestes.WinApp.ModuloDisciplina
{
    public partial class TelaCadastroDisciplinaForm : Form
    {
        public event GravarRegistroDelegate<Disciplina> onGravarRegistro;
        public TelaCadastroDisciplinaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
        private Disciplina disciplina;
        public Disciplina ObterDisciplina()
        {
            disciplina.Id = Convert.ToInt32(txtId.Text);
            disciplina.Nome = txtNome.Text;

            return disciplina;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.disciplina = ObterDisciplina();

            Result resultado = onGravarRegistro(disciplina);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public void ConfigurarDisciplina(Disciplina disciplina)
        {
            this.disciplina = disciplina;

            txtId.Text = disciplina.Id.ToString();
            txtNome.Text = disciplina.Nome;
        }
    }
}
