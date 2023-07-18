using GeraTestes.Dominio.Compartilhado;

namespace GeraTestes.Dominio.ModuloMateria
{
    public interface IRepositorioMateria : IRepositorio<Materia>
    {
        Materia SelecionarPorNome(string nome);
    }
}
