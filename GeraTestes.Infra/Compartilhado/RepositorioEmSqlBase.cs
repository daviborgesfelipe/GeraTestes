using GeraTestes.Dominio;

namespace GeraTestes.Infra.Sql.Compartilhado
{
    public abstract class RepositorioEmSqlBase<TEntidade, TMapeador>
        where TEntidade : EntidadeBase<TEntidade>
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        protected static string enderecoBanco =
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GeradorTesteDb;Integrated Security=True";

        protected abstract string sqlSelecionarTodos { get; }
        public virtual List<TEntidade> SelecionarTodos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<TEntidade> registros = new List<TEntidade>();

            TMapeador mapeador = new TMapeador();

            while (leitorItens.Read())
            {
                TEntidade registro = mapeador.ConverterRegistro(leitorItens);

                if (registro != null)
                    registros.Add(registro);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return registros;
        }

    }
}
