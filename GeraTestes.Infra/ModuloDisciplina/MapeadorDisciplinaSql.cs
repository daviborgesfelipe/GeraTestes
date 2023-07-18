﻿using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Infra.Sql.Compartilhado;

namespace GeraTestes.Infra.Sql.ModuloDisciplina
{
    public class MapeadorDisciplinaSql : MapeadorBase<Disciplina>
    {
        public override void ConfigurarParametros(SqlCommand comando, Disciplina disciplina)
        {
            comando.Parameters.AddWithValue("ID", disciplina.Id);
            comando.Parameters.AddWithValue("NOME", disciplina.Nome);
        }

        public override Disciplina ConverterRegistro(SqlDataReader leitorDisciplina)
        {
            if (leitorDisciplina.HasColumn("DISCIPLINA_ID") == false)
                return null;
            int id = Convert.ToInt32(leitorDisciplina["DISCIPLINA_ID"]);
            string nome = Convert.ToString(leitorDisciplina["DISCIPLINA_NOME"]);
            Disciplina disciplina = new Disciplina(id, nome);

            return disciplina;
        }
    }
}
