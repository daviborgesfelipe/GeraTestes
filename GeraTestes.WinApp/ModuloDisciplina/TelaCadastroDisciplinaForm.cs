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

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
