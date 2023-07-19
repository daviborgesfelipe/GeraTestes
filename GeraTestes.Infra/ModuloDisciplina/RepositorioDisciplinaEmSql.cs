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
        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID]    DISCIPLINA_ID
		           ,[NOME]  DISCIPLINA_NOME

	            FROM 
		            [TBDISCIPLINA]

		        WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBDISCIPLINA]
		        WHERE
			        [ID] = @ID";

        public void Editar(Disciplina registro)
        {
            throw new NotImplementedException();
        }
        public void Inserir(Disciplina novoRegistro)
        {
            throw new NotImplementedException();
        }
        public Disciplina SelecionarPorNome(string nome)
        {
            throw new NotImplementedException();
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

        //public List<Disciplina> SelecionarTodos(bool incluirMaterias = false, bool incluirQuestoes = false)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
