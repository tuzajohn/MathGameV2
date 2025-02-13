using FluentValidation;

namespace MathGame.src.Application.Features.PlayFeature;

public class PlayFeatureValidator : AbstractValidator<PlayFeatureRequest>
{
    public PlayFeatureValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Please, provide a name")
            .MinimumLength(4)
            .WithMessage("Name too short");
    }
}
