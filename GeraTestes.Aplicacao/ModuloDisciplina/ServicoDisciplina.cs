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
        public Result Excluir(Disciplina disciplina)
        {
            Log.Debug("Tentando excluir disciplina...{@d}", disciplina);

            try
            {
                repositorioDisciplina.Excluir(disciplina);
                Log.Debug("Disciplina {DisciplinaId} excluída com sucesso", disciplina.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();
                string msgErro = ObterMensagemDeErro(ex);
                erros.Add(msgErro);
                Log.Error(ex, msgErro + " {DisciplinaId}", disciplina.Id);

                return Result.Fail(erros);
            }
        }
        private static string ObterMensagemDeErro(SqlException ex)
        {
            string msgErro;
            if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
                msgErro = "Esta disciplina está relacionada com uma matéria e não pode ser excluída";
            else
                msgErro = "Esta disciplina não pode ser excluída";

            return msgErro;
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
