using GeraTestes.Dominio.ModuloQuestao;
using GeraTestes.Infra.Sql.Compartilhado;

namespace GeraTestes.Infra.Sql.ModuloQuestao
{
    public class RepositorioQuestaoEmSql : RepositorioEmSqlBase<Questao, MapeadorQuestaoSql>, IRepositorioQuestao
    {
        protected override string sqlSelecionarTodos =>
        @"SELECT 
	                Q.ID            QUESTAO_ID                
	               ,Q.ENUNCIADO     QUESTAO_ENUNCIADO
                   
	               ,M.ID            MATERIA_ID
	               ,M.NOME          MATERIA_NOME
                   ,M.SERIE         MATERIA_SERIE
                   
	               ,D.ID            DISCIPLINA_ID
	               ,D.NOME          DISCIPLINA_NOME

                FROM
	                TBQUESTAO Q 
    
                    INNER JOIN TBMATERIA M 
                        ON Q.MATERIA_ID = M.ID
                    
                    INNER JOIN TBDISCIPLINA D 
                        ON D.ID = M.DISCIPLINA_ID";

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlInserir => throw new NotImplementedException();

        public void Editar(Questao registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Questao registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Questao novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Questao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
