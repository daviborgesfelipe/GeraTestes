using GeraTestes.Dominio.ModuloTeste;
using GeraTestes.WinApp.Compartilhado;

namespace GeraTestes.WinApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();
            tabelaTestes.ConfigurarGridZebrado();
            tabelaTestes.ConfigurarGridSomenteLeitura();
            tabelaTestes.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Id",
                    HeaderText = "Id",
                    FillWeight=15F,
                    Visible=false 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Titulo",
                    HeaderText = "Título",
                    FillWeight=15F 
                },
                new DataGridViewTextBoxColumn 
                {
                    Name = "Disciplina.Nome", 
                    HeaderText = "Disciplina",
                    FillWeight=20F 
                },
                new DataGridViewTextBoxColumn 
                {
                    Name = "Provao", 
                    HeaderText = "Tipo",
                    FillWeight=25F
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Materia.Nome",
                    HeaderText = "Matéria", 
                    FillWeight=25F 
                }
            };

            return colunas;
        }
        public void AtualizarRegistros(List<Teste> testes)
        {
            tabelaTestes.Rows.Clear();

            foreach (var teste in testes)
            {
                string disciplina = teste.Provao ? teste.Disciplina.Nome : teste.Materia.Disciplina.Nome;

                tabelaTestes.Rows.Add(teste.Id, teste.Titulo, disciplina,
                    teste.Provao ? "Provão" : "Fixação da Matéria", teste.Materia?.Nome);
            }
        }
    }
}
