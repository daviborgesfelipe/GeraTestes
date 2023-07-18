using FluentValidation;

namespace GeraTestes.Dominio.ModuloQuestao
{
    public class ValidadorAlternativa : AbstractValidator<Alternativa>
    {
        public ValidadorAlternativa()
        {
            RuleFor(x => x.Resposta)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
