using FluentValidation;
using GeraTestes.Dominio.ModuloMateria;

namespace GeraTestes.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Enunciado)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);
        }
    }
}
