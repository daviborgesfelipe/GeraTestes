using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Infra.Sql.Compartilhado;

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

        protected override string sqlEditar =>
            @"UPDATE [TBDISCIPLINA]	
		        SET
			        [NOME] = @NOME
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID]    DISCIPLINA_ID
		           ,[NOME]  DISCIPLINA_NOME

	            FROM 
		            [TBDISCIPLINA]

		        WHERE
                    [ID] = @ID";

        private string sqlSelecionarPorNome =>
            @"SELECT 
		                    [ID]    DISCIPLINA_ID
		                   ,[NOME]  DISCIPLINA_NOME

	                    FROM 
		                    [TBDISCIPLINA]

		                WHERE
                            [NOME] = @NOME";
        #endregion

        public Disciplina SelecionarPorNome(string nome)
        {
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("NOME", nome) };

            return base.SelecionarRegistroPorParametro(sqlSelecionarPorNome, parametros);
        }

    }
}
