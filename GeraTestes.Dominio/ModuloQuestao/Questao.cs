using GeraTestes.Dominio.Compartilhado;
using GeraTestes.Dominio.ModuloMateria;

namespace GeraTestes.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {

        public List<Alternativa> Alternativas { get; set; }
        public string Enunciado { get; set; }
        public Materia Materia { get; set; }

        public Questao(int id, string enunciado, Materia materia)
        {
            Id = id;
            Enunciado = enunciado;
            Materia = materia;
        }

        public bool AdicionarAlternativa(Alternativa alternativa)
        {
            if (Alternativas.Contains(alternativa))
                return false;

            alternativa.Questao = this;
            Alternativas.Add(alternativa);

            return true;
        }
        public override void Atualizar(Questao registro)
        {
            Enunciado = registro.Enunciado;
            Materia = registro.Materia;
        }
        public override string ToString()
        {
            return Enunciado;
        }
        public override bool Equals(object obj)
        {
            return obj is Questao alternativa &&
                   Enunciado == alternativa.Enunciado &&
                   Materia == alternativa.Materia;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Alternativas, Enunciado, Materia);
        }

        public void RemoverAlternativa(Alternativa alternativa)
        {
            Alternativas.Remove(alternativa);

            RedefinirLetras();
        }
        private void RedefinirLetras()
        {
            char letra = 'A';

            foreach (var item in Alternativas)
            {
                item.Letra = letra;
                letra = letra.Next();
            }
        }
        public char GerarLetraAlternativa()
        {
            if (Alternativas == null)
                Alternativas = new List<Alternativa>();

            return Alternativas.Count == 0 ? 'A' :
                Alternativas.Select(x => x.Letra).Last().Next();
        }
    }
}
