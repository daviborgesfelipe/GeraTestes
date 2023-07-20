using FluentResults;
using GeraTestes.Dominio.ModuloQuestao;
using Microsoft.Data.SqlClient;
using Serilog;

namespace GeraTestes.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao
    {
        private IRepositorioQuestao repositorioQuestao;

        private ValidadorQuestao validadorQuestao;
        private ValidadorAlternativa validadorAlternativa;

        public ServicoQuestao(
            IRepositorioQuestao _repositorioQuestao,
            ValidadorQuestao _validadorQuestao, 
            ValidadorAlternativa _validadorAlternativa)
        {
            this.repositorioQuestao = _repositorioQuestao;
            this.validadorQuestao = _validadorQuestao;
            this.validadorAlternativa = _validadorAlternativa;
        }
        public Result Inserir(Questao questao)
        {
            Log.Debug("Tentando inserir questão...{@q}", questao);

            List<string> erros = ValidarQuestao(questao);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioQuestao.Inserir(questao);

                Log.Debug("Questão {QuestaoId} inserida com sucesso", questao.Id);

                return Result.Ok();
            }
            catch (SqlException exc)
            {
                string msgErro = "Falha ao tentar inserir questão.";

                Log.Error(exc, msgErro + "{@q}", questao);

                return Result.Fail(msgErro);
            }
        }
        private List<string> ValidarQuestao(Questao questao)
        {
            List<string> erros = validadorQuestao.Validate(questao)
                .Errors.Select(x => x.ErrorMessage).ToList();

            return erros;
        }

    }
}
