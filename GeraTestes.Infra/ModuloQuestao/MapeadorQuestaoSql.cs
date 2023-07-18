﻿using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.Dominio.ModuloQuestao;
using GeraTestes.Infra.Sql.Compartilhado;
using GeraTestes.Infra.Sql.ModuloDisciplina;
using GeraTestes.Infra.Sql.ModuloMateria;

namespace GeraTestes.Infra.Sql.ModuloQuestao
{
    public class MapeadorQuestaoSql : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao questao)
        {
            comando.Parameters.AddWithValue("ID", questao.Id);
            comando.Parameters.AddWithValue("ENUNCIADO", questao.Enunciado);
            comando.Parameters.AddWithValue("MATERIA_ID", questao.Materia.Id);
        }

        public override Questao ConverterRegistro(SqlDataReader leitorQuestao)
        {
            Disciplina disciplina = new MapeadorDisciplinaSql().ConverterRegistro(leitorQuestao);
            Materia materia = new MapeadorMateriaSql().ConverterRegistro(leitorQuestao);
            if (materia != null && disciplina != null)
                materia.Disciplina = disciplina;

            int id = Convert.ToInt32(leitorQuestao["QUESTAO_ID"]);
            string enunciado = Convert.ToString(leitorQuestao["QUESTAO_ENUNCIADO"]);
            Questao questao = new Questao(id, enunciado, materia);

            return questao;
        }
    }
}
