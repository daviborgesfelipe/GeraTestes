using GeraTestes.Dominio.ModuloQuestao;

namespace GeraTestes.Infra.Sql.ModuloQuestao
{
    public class MapeadorAlternativaSql
    {
        public SqlParameter[] ObterParametros(Alternativa alternativa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter("ID", alternativa.Id),
                new SqlParameter("LETRA", alternativa.Letra),
                new SqlParameter("RESPOSTA", alternativa.Resposta),
                new SqlParameter("CORRETA", alternativa.Correta),
                new SqlParameter("QUESTAO_ID", alternativa.Questao.Id)
            };
            return parametros.ToArray();
        }

        public Alternativa ConverterRegistro(SqlDataReader leitorAlternativa)
        {
            int id = Convert.ToInt32(leitorAlternativa["ALTERNATIVA_ID"]);
            string letraString = leitorAlternativa["ALTERNATIVA_LETRA"].ToString();
            char letra = !string.IsNullOrEmpty(letraString) ? letraString[0] : default(char);
            string resposta = Convert.ToString(leitorAlternativa["ALTERNATIVA_RESPOSTA"]);
            bool correta = Convert.ToBoolean(leitorAlternativa["ALTERNATIVA_CORRETA"]);
            Alternativa alternativa = new Alternativa(id, letra, resposta, correta);

            return alternativa;
        }
    }
}
