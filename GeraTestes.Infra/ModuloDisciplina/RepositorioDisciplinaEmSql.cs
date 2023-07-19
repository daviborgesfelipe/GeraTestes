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
        protected override string sqlInserir =>
            @"INSERT INTO [TBDISCIPLINA]
                (
                    [NOME]
                )    
                 VALUES
                (
                    @NOME
                );SELECT SCOPE_IDENTITY();";
        private string sqlSelecionarPorNome =>
            @"SELECT 
		            [ID]    DISCIPLINA_ID
		           ,[NOME]  DISCIPLINA_NOME

	            FROM 
		            [TBDISCIPLINA]

		        WHERE
                    [NOME] = @NOME";

        public void Editar(Disciplina registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Disciplina registro)
        {
            throw new NotImplementedException();
        }

        public Disciplina SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Disciplina SelecionarPorNome(string nome)
        {
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("NOME", nome) };

            return base.SelecionarRegistroPorParametro(sqlSelecionarPorNome, parametros);
        }

        #endregion

        public virtual List<Disciplina> SelecionarTodos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<Disciplina> registros = new List<Disciplina>();

            MapeadorDisciplinaSql mapeador = new MapeadorDisciplinaSql();

            while (leitorItens.Read())
            {
                Disciplina registro = mapeador.ConverterRegistro(leitorItens);

                if (registro != null)
                    registros.Add(registro);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return registros;
        }
    }
}
