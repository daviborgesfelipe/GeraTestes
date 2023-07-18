using GeraTestes.Dominio.ModuloDisciplina;
using Serilog;
using System.Runtime.CompilerServices;

namespace GeraTestes.Aplicacao.ModuloDisciplina
{
    public class ServicoDisciplina
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private ValidadorDisciplina validadorDisciplina;

        public ServicoDisciplina(
            IRepositorioDisciplina repositorioDisciplina,
            ValidadorDisciplina validadorDisciplina
            )
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.validadorDisciplina = validadorDisciplina;
        }
        private List<string> ValidarDisciplina(Disciplina disciplina)
        {
            List<string> erros = validadorDisciplina.Validate(disciplina)
                .Errors.Select(x => x.ErrorMessage).ToList();

            if (NomeDuplicado(disciplina))
                erros.Add($"Este nome '{disciplina.Nome}' já está sendo utilizado na aplicação");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Disciplina disciplina)
        {
            Disciplina disciplinaEncontrada = repositorioDisciplina.SelecionarPorNome(disciplina.Nome);

            if (disciplinaEncontrada != null &&
                disciplinaEncontrada.Id != disciplina.Id &&
                disciplinaEncontrada.Nome == disciplina.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
