using FluentValidation;

namespace TesteBackendEeM.Aplicacao.Responsaveis
{
    public class CreateResponsavelValidator : AbstractValidator<CreateResponsavel>
    {

        public CreateResponsavelValidator()
        {
            RuleFor(x => x.Nome.ToString())
                    .NotEmpty()
                    .WithMessage("Nome é obrigatório")
                    .MaximumLength(25)
                    .WithMessage("Campo Nome deve ser preenchido");
        }
    }
}
