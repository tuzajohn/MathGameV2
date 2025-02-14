using FluentValidation;

namespace MathGame.src.Application.Features.SignInFeature;

public class SignInFeatureValidator : AbstractValidator<SignInFeatureRequest>
{
    public SignInFeatureValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email field cannot be empty");

        RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("Password field cannot be empty");
    }
}
