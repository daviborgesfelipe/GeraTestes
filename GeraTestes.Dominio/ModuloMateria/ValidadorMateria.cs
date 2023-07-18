using FluentValidation;

namespace GeraTestes.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .Custom(ValidarCaracteresInvalidos);
        }
        private void ValidarCaracteresInvalidos(string nome, ValidationContext<Materia> contextoValidacao)
        {
            bool temCaracteresInvalidos = false;

            foreach (char letra in nome)
            {
                if (letra == ' ')
                    continue;

                if (char.IsLetterOrDigit(letra) == false)
                    temCaracteresInvalidos = true;
            }

            if (temCaracteresInvalidos)
                contextoValidacao.AddFailure($"'Nome' da matéria deve ser composta por letras e números.");
        }
    }
}
