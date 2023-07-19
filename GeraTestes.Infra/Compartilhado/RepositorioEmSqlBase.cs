using GeraTestes.Dominio;
using GeraTestes.Dominio.ModuloMateria;

namespace GeraTestes.Infra.Sql.Compartilhado
{
    public abstract class RepositorioEmSqlBase<TEntidade, TMapeador>
        where TEntidade : EntidadeBase<TEntidade>
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        protected static string enderecoBanco =
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GeradorTesteDb;Integrated Security=True";

        protected abstract string sqlInserir { get; }
        protected abstract string sqlSelecionarTodos { get; }

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
        public void Editar(TEntidade registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(TEntidade registro)
        {
            throw new NotImplementedException();
        }
        public TEntidade SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        protected static List<T> SelecionarRegistros<T>(string sql, ConverterRegistroDelegate<T> ConverterRegistro, SqlParameter[] parametros)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sql, conexaoComBanco);

            foreach (SqlParameter parametro in parametros)
            {
                comandoSelecao.Parameters.Add(parametro);
            }

            conexaoComBanco.Open();
            SqlDataReader leitorRegistros = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            while (leitorRegistros.Read())
            {
                T registro = ConverterRegistro(leitorRegistros);

                registros.Add(registro);
            }

            conexaoComBanco.Close();

            return registros;
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
