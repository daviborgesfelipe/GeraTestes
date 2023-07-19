using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.Dominio.ModuloQuestao;

namespace GeraTestes.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }
        public bool Provao { get; set; }
        public int QuantidadeQuestoes { get; set; }
        public bool QuestoesSorteadas { get; set; }

        public List<Questao> Questoes { get; set; }
        public DateTime DataGeracao { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }

        public Teste(int id, string titulo, bool provao, DateTime DataGeracao, int quantidadeQuestoes)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Provao = provao;
            this.DataGeracao = DataGeracao;
            this.QuantidadeQuestoes = quantidadeQuestoes;
        }

        public override void Atualizar(Teste teste)
        {
            Titulo = teste.Titulo;
            Provao = teste.Provao;
            DataGeracao = teste.DataGeracao;
            Disciplina = teste.Disciplina;
            Materia = teste.Materia;
            QuantidadeQuestoes = teste.QuantidadeQuestoes;
            Questoes = teste.Questoes;
        }
        public override bool Equals(object obj)
        {
            return obj is Teste teste &&
                   Titulo == teste.Titulo &&
                   Provao == teste.Provao &&
                   QuantidadeQuestoes ==  teste.QuantidadeQuestoes &&
                   QuestoesSorteadas == teste.QuestoesSorteadas;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(
                Titulo,
                Provao,
                QuantidadeQuestoes,
                QuestoesSorteadas,
                Questoes,
                DataGeracao,
                Disciplina,
                Materia);
        }
        public override string ToString()
        {
            return string.Format("{0}", Titulo);
        }
    }
}
