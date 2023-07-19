using GeraTestes.Dominio.ModuloTeste;
using GeraTestes.Infra.Sql.Compartilhado;

namespace GeraTestes.Infra.Sql.ModuloTeste
{
    public class RepositorioTesteEmSql :
        RepositorioEmSqlBase<Teste, MapeadorTesteSql>, IRepositorioTeste
    {
        protected override string sqlSelecionarTodos =>
             @"SELECT        
	                T.ID                    TESTE_ID
	               ,T.TITULO                TESTE_TITULO
	               ,T.DATAGERACAO           TESTE_DATAGERACAO
	               ,T.PROVAO                TESTE_PROVAO
 	               ,T.QUANTIDADEQUESTOES    TESTE_QUANTIDADEQUESTOES
                   
	               ,D.ID                    DISCIPLINA_ID
	               ,D.NOME                  DISCIPLINA_NOME
	               
	               ,M.ID                    MATERIA_ID
	               ,M.NOME                  MATERIA_NOME
	               ,M.SERIE                 MATERIA_SERIE 	

                FROM  
	                TBTESTE T 
                    
                    INNER JOIN TBDISCIPLINA D
                        ON T.DISCIPLINA_ID = D.ID

                    LEFT JOIN TBMATERIA M 
                        ON T.MATERIA_ID = M.ID";

        public void Editar(Teste registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Teste registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Teste novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Teste SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
