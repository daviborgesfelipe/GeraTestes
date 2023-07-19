using FluentResults;
using GeraTestes.Dominio.ModuloMateria;
using Microsoft.Data.SqlClient;
using Serilog;

namespace GeraTestes.Aplicacao.ModuloMateria
{
    public class ServicoMateria
    {
        private IRepositorioMateria repositorioMateria;

        private ValidadorMateria validadorMateria;
        public ServicoMateria(
            IRepositorioMateria _repositorioMateria,
            ValidadorMateria _validadorMatria
            )
        {
            this.repositorioMateria = _repositorioMateria;
            this.validadorMateria = _validadorMatria;
        }
        public Result Inserir(Materia materia)
        {
            Log.Debug("Tentando inserir matéria...{@m}", materia);

            List<string> erros = ValidarMateria(materia);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioMateria.Inserir(materia);

                Log.Debug("Matéria {MateriaId} inserida com sucesso", materia.Id);

                return Result.Ok();
            }
            catch (SqlException exc)
            {
                string msgErro = "Falha ao tentar inserir matéria.";

                Log.Error(exc, msgErro + "{@m}", materia);

                return Result.Fail(msgErro);
            }
        }
        private List<string> ValidarMateria(Materia materia)
        {
            List<string> erros = validadorMateria.Validate(materia)
                .Errors.Select(x => x.ErrorMessage).ToList();

            if (NomeDuplicado(materia))
                erros.Add($"Este nome '{materia.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Materia materia)
        {
            Materia materiaEncontrada = repositorioMateria.SelecionarPorNome(materia.Nome);

            if (materiaEncontrada != null &&
                materiaEncontrada.Id != materia.Id &&
                materiaEncontrada.Nome == materia.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
