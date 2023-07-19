﻿using GeraTestes.Dominio.ModuloMateria;
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
        protected override string sqlInserir =>
        @"INSERT INTO [TBMATERIA]
                   (
                        [NOME],
                        [SERIE],
                        [DISCIPLINA_ID]
                   )
                VALUES
                   (
                        @NOME,
                        @SERIE,
                        @DISCIPLINA_ID
                   ); 

                SELECT SCOPE_IDENTITY()";
        private string sqlSelecionarPorNome =>
        @"SELECT 
	                MT.ID       MATERIA_ID
	               ,MT.NOME     MATERIA_NOME
	               ,MT.SERIE    MATERIA_SERIE

	               ,D.ID        DISCIPLINA_ID
	               ,D.NOME      DISCIPLINA_NOME

                FROM
	                TBMATERIA AS MT 
                    
                    INNER JOIN TBDISCIPLINA AS D                     
                        ON MT.DISCIPLINA_ID = D.ID

                WHERE
                    MT.NOME = @NOME";
        protected override string sqlEditar =>
            @"UPDATE [TBMATERIA]

	        	        SET
                            [NOME] = @NOME,
	        		        [DISCIPLINA_ID] = @DISCIPLINA_ID,
                            [SERIE] = @SERIE

	        	        WHERE
	        		        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
	            MT.ID       MATERIA_ID
	           ,MT.NOME     MATERIA_NOME
	           ,MT.SERIE    MATERIA_SERIE

	           ,D.ID        DISCIPLINA_ID
	           ,D.NOME      DISCIPLINA_NOME

            FROM
	            TBMATERIA AS MT 
                
                INNER JOIN TBDISCIPLINA AS D                     
                    ON MT.DISCIPLINA_ID = D.ID

            WHERE
                MT.ID = @ID";

        public Materia SelecionarPorNome(string nome)
        {
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("NOME", nome) };

            return base.SelecionarRegistroPorParametro(sqlSelecionarPorNome, parametros);
        }
    }
}
