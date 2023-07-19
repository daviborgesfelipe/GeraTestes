using FluentValidation;

namespace GeraTestes.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
