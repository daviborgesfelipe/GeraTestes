using GeraTestes.Dominio.Compartilhado;

namespace GeraTestes.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina : IRepositorio<Disciplina>
    {
        Disciplina SelecionarPorNome(string nome);
        //List<Disciplina> SelecionarTodos(
        //    bool incluirMaterias = false, 
        //    bool incluirQuestoes = false
        //    );
    }
}
