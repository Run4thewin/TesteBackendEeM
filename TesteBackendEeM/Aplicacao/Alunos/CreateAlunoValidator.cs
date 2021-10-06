using FluentValidation;

namespace TesteBackendEeM.Aplicacao.Alunos
{
    public class CreateAlunoValidator : AbstractValidator<CreateAluno>
    {

        public CreateAlunoValidator()
        {
            RuleFor(x => x.Nome.ToString())
                    .NotEmpty()
                    .WithMessage("Nome é obrigatório")
                    .MaximumLength(25)
                    .WithMessage("Campo Nome deve ser preenchido");
        }
    }
}
