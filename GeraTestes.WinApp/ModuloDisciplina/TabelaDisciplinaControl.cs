using GeraTestes.WinApp.Compartilhado;
using GeraTestes.Dominio.ModuloDisciplina;

namespace GeraTestes.WinApp.ModuloDisciplina
{
    public partial class TabelaDisciplinaControl : UserControl
    {
        public TabelaDisciplinaControl()
        {
            InitializeComponent();
            tabelaDisciplina.ConfigurarGridZebrado();
            tabelaDisciplina.ConfigurarGridSomenteLeitura();
            tabelaDisciplina.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Id",
                    HeaderText = "Id",
                    FillWeight=15F 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Nome",
                    HeaderText = "Nome",
                    FillWeight=85F 
                }
            };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return tabelaDisciplina.SelecionarId();
        }

        public void AtualizarRegistros(List<Disciplina> disciplinas)
        {
            tabelaDisciplina.Rows.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                tabelaDisciplina.Rows.Add(disciplina.Id, disciplina.Nome);
            }
        }
    }
}
