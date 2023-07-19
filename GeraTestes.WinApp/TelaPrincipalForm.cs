using GeraTestes.Aplicacao.ModuloDisciplina;
using GeraTestes.Aplicacao.ModuloMateria;
using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.Infra.Sql.ModuloDisciplina;
using GeraTestes.Infra.Sql.ModuloMateria;
using GeraTestes.WinApp.Compartilhado;
using GeraTestes.WinApp.ModuloDisciplina;
using GeraTestes.WinApp.ModuloMateria;
using System.Runtime.CompilerServices;

namespace GeraTestes.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        public static TelaPrincipalForm Instancia { get; private set; }
        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            controladores = new Dictionary<string, ControladorBase>();
            ConfirgurarControlador();
        }

        private Dictionary<string, ControladorBase> controladores;
        private ControladorBase controlador;

        #region AtualizacaoRodape
        public void AtualizarRodape()
        {
            string mensagemRodape = controlador.ObterMensagemRodape();
            AtualizarRodape(mensagemRodape);
        }
        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }
        #endregion

        #region Configuracao
        private void ConfirgurarControlador()
        {
            IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaEmSql();
            IRepositorioMateria repositorioMateria = new RepositorioMateriaEmSql();

            ValidadorDisciplina validadorDisciplina = new ValidadorDisciplina();
            ValidadorMateria validadorMateria = new ValidadorMateria();

            ServicoDisciplina servicoDisciplina = new ServicoDisciplina(
                repositorioDisciplina,
                validadorDisciplina
                );
            ServicoMateria servicoMateria = new ServicoMateria(
                repositorioMateria,
                validadorMateria
                );

            controladores.Add("ControladorDisciplina", new ControladorDisciplina(
                repositorioDisciplina,
                servicoDisciplina
                ));
            controladores.Add("ControladorMateria", new ControladorMateria(
                repositorioDisciplina,
                repositorioMateria,
                servicoMateria));
        }
        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();
            panelRegistros.Controls.Clear();
            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }
        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;
                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);
                ConfigurarBotoes(configuracao);
            }
        }
        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnDuplicar.Enabled = configuracao.DuplicarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnGerarPdf.Enabled = configuracao.GerarPdfHabilitado;
            btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
        }
        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnGerarPdf.ToolTipText = configuracao.TooltipGerarPdf;
            btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
        }
        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();
            ConfigurarListagem();

            string mensagemRodape = controlador.ObterMensagemRodape();
            AtualizarRodape(mensagemRodape);
        }
        #endregion

        private void disciplinaMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
        }

        private void materiasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorMateria"]);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }
    }
}