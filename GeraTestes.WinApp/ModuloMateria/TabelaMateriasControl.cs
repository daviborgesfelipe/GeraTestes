using GeraTestes.Dominio.Compartilhado;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.WinApp.Compartilhado;

namespace GeraTestes.WinApp.ModuloMateria
{
    public partial class TabelaMateriasControl : UserControl
    {
        public TabelaMateriasControl()
        {
            InitializeComponent();
            tabelaMaterias.ConfigurarGridSomenteLeitura();
            tabelaMaterias.ConfigurarGridZebrado();
            tabelaMaterias.Columns.AddRange(ObterColunas());
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
                    FillWeight=35F 
                },

                new DataGridViewTextBoxColumn 
                { 
                    Name = "Disciplina.Nome",
                    HeaderText = "Disciplina",
                    FillWeight=25F
                },

                new DataGridViewTextBoxColumn 
                { 
                    Name = "Serie",
                    HeaderText = "Série", 
                    FillWeight=25F 
                },
            };

            return colunas;
        }
        public void AtualizarRegistros(List<Materia> materias)
        {
            tabelaMaterias.Rows.Clear();

            foreach (var materia in materias)
            {
                tabelaMaterias.Rows.Add(
                    materia.Id,
                    materia.Nome,
                    materia.Disciplina.Nome,
                    materia.Serie.GetDescription()
                    );
            }
        }
        public int ObtemIdSelecionado()
        {
            return tabelaMaterias.SelecionarId();
        }
    }
}
