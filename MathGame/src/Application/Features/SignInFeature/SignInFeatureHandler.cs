
using FluentValidation;
using MathGame.src.Application.Utils.Extensions;

namespace MathGame.src.Application.Features.SignInFeature;

public class SignInFeatureHandler : IRequestHandler<SignInFeatureRequest, MessageResponse>
{
    readonly IAccountRepository _accountRepository;
    readonly IValidator<SignInFeatureRequest> _validator;
    public SignInFeatureHandler(IValidator<SignInFeatureRequest> validator, IAccountRepository accountRepository)
    {
        _validator = validator;
        _accountRepository = accountRepository;
    }
    public async Task<MessageResponse> Handle(SignInFeatureRequest request, CancellationToken cancellationToken)
    {
        var response = _validator.ValidateAndHandleErrors(request);
        if (response.Code != 0)
            return response;

        var loginResponse = await _accountRepository.Login(request.Email, request.Password);


        if (loginResponse.Code == 0)
        {
            //TODO: Cache Response
        }


        return loginResponse;
    }
}
