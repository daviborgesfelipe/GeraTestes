﻿using GeraTestes.Dominio;
using GeraTestes.Dominio.ModuloDisciplina;

namespace GeraTestes.Infra.Sql.Compartilhado
{
    public abstract class RepositorioEmSqlBase<TEntidade, TMapeador>
        where TEntidade : EntidadeBase<TEntidade>
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        protected static string enderecoBanco =
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GeradorTesteDb;Integrated Security=True";
        protected abstract string sqlSelecionarPorId { get; }
        protected abstract string sqlExcluir { get; }
        protected abstract string sqlSelecionarTodos { get; }
        protected abstract string sqlEditar { get; }
        protected abstract string sqlSelecionarPorId { get; }
        protected abstract string sqlInserir { get; }

        public virtual void Editar(TEntidade registro)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            TMapeador mapeador = new TMapeador();
            //adiciona os parâmetros no comando
            mapeador.ConfigurarParametros(comandoEditar, registro);

            //executa o comando
            comandoEditar.ExecuteNonQuery();

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
        public virtual TEntidade SelecionarPorId(int id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarPorId = conexaoComBanco.CreateCommand();
            comandoSelecionarPorId.CommandText = sqlSelecionarPorId;

            //adicionar parametro
            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            //executa o comando
            SqlDataReader leitorItems = comandoSelecionarPorId.ExecuteReader();

            TEntidade registro = null;

            TMapeador mapeador = new TMapeador();

            if (leitorItems.Read())
                registro = mapeador.ConverterRegistro(leitorItems);

            //encerra a conexão
            conexaoComBanco.Close();

            return registro;
        }



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


        public virtual void Excluir(TEntidade registroSelecionado)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            //adiciona os parâmetros no comando
            comandoExcluir.Parameters.AddWithValue("ID", registroSelecionado.Id);

            //executa o comando
            comandoExcluir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }
        public virtual TEntidade SelecionarPorId(int id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarPorId = conexaoComBanco.CreateCommand();
            comandoSelecionarPorId.CommandText = sqlSelecionarPorId;

            //adicionar parametro
            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            //executa o comando
            SqlDataReader leitorItems = comandoSelecionarPorId.ExecuteReader();

            TEntidade registro = null;

            TMapeador mapeador = new TMapeador();

            if (leitorItems.Read())
                registro = mapeador.ConverterRegistro(leitorItems);

            //encerra a conexão
            conexaoComBanco.Close();

            return registro;
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
    }
}
