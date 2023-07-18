using GeraTestes.Dominio;

namespace GeraTestes.Infra.Sql.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract void ConfigurarParametros(SqlCommand comando, T registro);
        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);
    }
}
