using GeraTestes.Dominio.Compartilhado;

namespace GeraTestes.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina : IRepositorio<Disciplina>
    {
        Disciplina SelecionarPorNome(string nome);
    }
}
