using FluentResults;
using GeraTestes.Dominio.ModuloDisciplina;
using Microsoft.Data.SqlClient;
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
        public Result Inserir(Disciplina disciplina)
        {
            List<string> erros = ValidarDisciplina(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioDisciplina.Inserir(disciplina);

                Log.Debug("Disciplina {DisciplinaId} inserida com sucesso", disciplina.Id);

                return Result.Ok();
            }
            catch (SqlException exc)
            {
                string msgErro = "Falha ao tentar inserir disciplina.";

                Log.Error(exc, msgErro + "{@d}", disciplina);

                return Result.Fail(msgErro);
            }
        }
        public Result Editar(Disciplina disciplina)
        {
            Log.Debug("Tentando editar disciplina...{@d}", disciplina);

            List<string> erros = ValidarDisciplina(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioDisciplina.Editar(disciplina);

                Log.Debug("Disciplina {DisciplinaId} editada com sucesso", disciplina.Id);

                return Result.Ok();
            }
            catch (SqlException exc)
            {
                string msgErro = "Falha ao tentar editar disciplina.";

                Log.Error(exc, msgErro + "{@d}", disciplina);

                return Result.Fail(msgErro);
            }
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
