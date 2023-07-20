using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
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
        private string sqlSelecionarPorNome =>
            @"SELECT 
	        	            [ID]    DISCIPLINA_ID
	        	           ,[NOME]  DISCIPLINA_NOME

	                    FROM 
	        	            [TBDISCIPLINA]

	        	        WHERE
                            [NOME] = @NOME";

        protected override string sqlInserir =>
            @"INSERT INTO [TBDISCIPLINA]
                (
                    [NOME]
                )    
                 VALUES
                (
                    @NOME
                );SELECT SCOPE_IDENTITY();";
        protected override string sqlEditar =>
            @"UPDATE [TBDISCIPLINA]	
	        	        SET
	        		        [NOME] = @NOME
	        	        WHERE
	        		        [ID] = @ID";
        #endregion
        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        public Disciplina SelecionarPorNome(string nome)
        {
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("NOME", nome) };

            return base.SelecionarRegistroPorParametro(sqlSelecionarPorNome, parametros);
        }



    }
}
