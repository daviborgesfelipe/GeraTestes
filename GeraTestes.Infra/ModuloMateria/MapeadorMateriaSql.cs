using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.Infra.Sql.Compartilhado;
using GeraTestes.Infra.Sql.ModuloDisciplina;

namespace GeraTestes.Infra.Sql.ModuloMateria
{
    public class MapeadorMateriaSql : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia materia)
        {
            comando.Parameters.AddWithValue("ID", materia.Id);
            comando.Parameters.AddWithValue("NOME", materia.Nome);
            comando.Parameters.AddWithValue("SERIE", materia.Serie);
            comando.Parameters.AddWithValue("DISCIPLINA_ID", materia.Disciplina.Id);
        }

        public override Materia ConverterRegistro(SqlDataReader leitorMateria)
        {
            if (leitorMateria.HasColumn("MATERIA_ID") == false)
                return null;

            int id = Convert.ToInt32(leitorMateria["MATERIA_ID"]);

            string nome = Convert.ToString(leitorMateria["MATERIA_NOME"]);
            SerieMateriaEnum serie = (SerieMateriaEnum)leitorMateria["MATERIA_SERIE"];
            Disciplina disciplina = new MapeadorDisciplinaSql().ConverterRegistro(leitorMateria);
            Materia materia = new Materia(id, nome, serie, disciplina);

            return materia;
        }
    }
}
