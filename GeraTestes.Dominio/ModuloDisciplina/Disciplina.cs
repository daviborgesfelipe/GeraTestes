using GeraTestes.Dominio;
using GeraTestes.Dominio.ModuloMateria;

namespace GeraTestes.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string Nome { get; set; }
        public List<Materia> Materias { get; set; }

        #region Contrutores
        public Disciplina()
        {
            Materias = new List<Materia>();
        }
        public Disciplina(string nome) : this()
        {
            Nome = nome;
        }
        public Disciplina(int id, string nome) : this(nome)
        {
            Id = id;
        }
        #endregion

        public override void Atualizar(Disciplina disciplina)
        {
            Nome = disciplina.Nome;
        }
        public override bool Equals(object obj)
        {
            return obj is Disciplina disciplina &&
                   Id == disciplina.Id &&
                   Nome == disciplina.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }
    }
}
