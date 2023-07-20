using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.Infra.Sql.Compartilhado;

namespace GeraTestes.Infra.Sql.ModuloMateria
{
    public class RepositorioMateriaEmSql : RepositorioEmSqlBase<Materia, MapeadorMateriaSql>, IRepositorioMateria
    {
        protected override string sqlSelecionarTodos =>
            @"SELECT 
	            MT.ID       MATERIA_ID
	           ,MT.NOME     MATERIA_NOME
	           ,MT.SERIE    MATERIA_SERIE

	           ,D.ID        DISCIPLINA_ID
	           ,D.NOME      DISCIPLINA_NOME

            FROM
	            TBMATERIA AS MT 
                
                INNER JOIN TBDISCIPLINA AS D                     
                    ON MT.DISCIPLINA_ID = D.ID";

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlInserir => throw new NotImplementedException();

        #region CRUD
        public void Editar(Materia registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Materia registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Materia novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Materia SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Materia SelecionarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public virtual List<Materia> SelecionarTodos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<Materia> registros = new List<Materia>();

            MapeadorMateriaSql mapeador = new MapeadorMateriaSql();

            while (leitorItens.Read())
            {
                Materia registro = mapeador.ConverterRegistro(leitorItens);

                if (registro != null)
                    registros.Add(registro);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return registros;
        }
        #endregion
    }
}
