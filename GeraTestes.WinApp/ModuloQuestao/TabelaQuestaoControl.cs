using GeraTestes.Dominio.ModuloQuestao;
using GeraTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraTestes.WinApp.ModuloQuestao
{
    public partial class TabelaQuestaoControl : UserControl
    {
        public TabelaQuestaoControl()
        {
            InitializeComponent();
            tabelaQuestao.ConfigurarGridSomenteLeitura();
            tabelaQuestao.ConfigurarGridZebrado();
            tabelaQuestao.Columns.AddRange(ObterColunas());
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
                    Name = "Materia.Nome", 
                    HeaderText = "Matéria",
                    FillWeight=25F 
                },

                new DataGridViewTextBoxColumn 
                { 
                    Name = "Disciplina.Nome",
                    HeaderText = "Disciplina",
                    FillWeight=25F
                }

            };

            return colunas;
        }
        public void AtualizarRegistros(List<Questao> questoes)
        {
            tabelaQuestao.Rows.Clear();

            foreach (var questao in questoes)
            {
                tabelaQuestao.Rows.Add(questao.Id, questao.Enunciado, questao?.Materia?.Nome, questao.Materia?.Disciplina?.Nome);
            }
        }
    }
}
