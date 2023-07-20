using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.Dominio.ModuloQuestao;
using GeraTestes.Infra.Sql.Compartilhado;
using GeraTestes.Infra.Sql.ModuloMateria;
using GeraTestes.Infra.Sql.ModuloQuestao;

namespace GeraTestes.Infra.Sql.ModuloDisciplina
{
    public class RepositorioDisciplinaEmSql : RepositorioEmSqlBase<Disciplina, MapeadorDisciplinaSql>, IRepositorioDisciplina
    {
        #region Queries
        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID]    DISCIPLINA_ID
		           ,[NOME]  DISCIPLINA_NOME

	            FROM 
		            [TBDISCIPLINA]";

        protected override string sqlInserir => throw new NotImplementedException();

        private string sqlSelecionarMateriasDaDisciplina =>
            @"SELECT 
		            [ID]        MATERIA_ID 
		           ,[NOME]      MATERIA_NOME
                   ,[SERIE]     MATERIA_SERIE

	            FROM 
		            [TBMATERIA]

		        WHERE
                    [DISCIPLINA_ID] = @DISCIPLINA_ID";

        private string sqlSelecionarQuestoesDaMateria =>
            @"SELECT 

		            [ID]            QUESTAO_ID
		           ,[ENUNCIADO]     QUESTAO_ENUNCIADO
	               ,[JAUTILIZADA]   QUESTAO_JAUTILIZADA                        

	            FROM 
		            [TBQUESTAO]

		        WHERE
                    [MATERIA_ID] = @MATERIA_ID AND [JAUTILIZADA] = 0";

        public void Editar(Disciplina registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Disciplina registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Disciplina novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Disciplina SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Disciplina SelecionarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        #endregion

        public List<Disciplina> SelecionarTodos(bool incluirMaterias = false, bool incluirQuestoes = false)
        {
            List<Disciplina> disciplinas = base.SelecionarTodos();

            if (incluirMaterias)
            {
                foreach (Disciplina disciplina in disciplinas)
                {
                    CarregarMaterias(disciplina);

                    if (incluirQuestoes)
                    {
                        foreach (Materia materia in disciplina.Materias)
                        {
                            CarregarQuestoes(materia);
                        }
                    }
                }
            }

            return disciplinas;
        }

        private void CarregarMaterias(Disciplina disciplina)
        {
            MapeadorMateriaSql mapeador = new MapeadorMateriaSql();

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("DISCIPLINA_ID", disciplina.Id) };

            List<Materia> materias = SelecionarRegistros(sqlSelecionarMateriasDaDisciplina, mapeador.ConverterRegistro, parametros);

            foreach (Materia materia in materias)
            {
                disciplina.AdicionarMateria(materia);
            }
        }

        private void CarregarQuestoes(Materia materia)
        {
            MapeadorQuestaoSql mapeador = new MapeadorQuestaoSql();

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("MATERIA_ID", materia.Id) };

            List<Questao> questoes = SelecionarRegistros(sqlSelecionarQuestoesDaMateria, mapeador.ConverterRegistro, parametros);

            foreach (Questao questao in questoes)
            {
                materia.AdicionaQuestao(questao);
            }
        }
    }
}
