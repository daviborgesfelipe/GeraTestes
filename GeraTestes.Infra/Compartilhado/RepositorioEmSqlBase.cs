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
        protected abstract string sqlInserir { get; }


        public virtual void Inserir(TEntidade novoRegistro)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            TMapeador mapeador = new TMapeador();

            //adiciona os parâmetros no comando
            mapeador.ConfigurarParametros(comandoInserir, novoRegistro);

            //executa o comando
            object id = comandoInserir.ExecuteScalar();

            novoRegistro.Id = Convert.ToInt32(id);

            //encerra a conexão
            conexaoComBanco.Close();
        }
        public virtual TEntidade SelecionarRegistroPorParametro(string sqlSelecionarPorParametro, SqlParameter[] parametros)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarPorParametro = conexaoComBanco.CreateCommand();
            comandoSelecionarPorParametro.CommandText = sqlSelecionarPorParametro;

            foreach (SqlParameter parametro in parametros)
            {
                comandoSelecionarPorParametro.Parameters.Add(parametro);
            }

            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarPorParametro.ExecuteReader();

            TMapeador mapeador = new TMapeador();

            TEntidade registro = default(TEntidade);
            if (leitorItens.Read())
                registro = mapeador.ConverterRegistro(leitorItens);

            //encerra a conexão
            conexaoComBanco.Close();

            return registro;
        }

    }
}
