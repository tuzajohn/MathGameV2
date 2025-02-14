namespace MathGame.src.Application.Features.SignInFeature;

public class SignInFeatureRequest : IRequest<MessageResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
