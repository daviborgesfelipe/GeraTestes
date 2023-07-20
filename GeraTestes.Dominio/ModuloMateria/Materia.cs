using GeraTestes.Dominio.Compartilhado;
using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeraTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public SerieMateriaEnum Serie { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Questao> Questoes { get; set; }

        #region Contrutores
        public Materia()
        {
            Questoes = new List<Questao>();
        }

        public Materia(string n, SerieMateriaEnum s, Disciplina disciplina) : this()
        {
            Nome = n;
            Serie = s;
            Disciplina = disciplina;
        }

        public Materia(int id, string nome, SerieMateriaEnum serie, Disciplina disciplina) : this(nome, serie, disciplina)
        {
            this.Id = id;
        }
        #endregion
        public override void Atualizar(Materia materia)
        {
            Nome = materia.Nome;
            Disciplina = materia.Disciplina;
            Serie = materia.Serie;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", Nome, Serie.GetDescription());
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Serie, Disciplina);
        }
        public override bool Equals(object obj)
        {
            return obj is Materia materia &&
                   Id == materia.Id &&
                   Nome == materia.Nome &&
                   Serie == materia.Serie;
        }

        public void AdicionaQuestao(Questao questao)
        {
            if (Questoes.Contains(questao))
                return;

            Questoes.Add(questao);
            questao.Materia = this;
        }
    }
}
