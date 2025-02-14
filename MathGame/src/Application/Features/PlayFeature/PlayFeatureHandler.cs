using FluentValidation;
using MathGame.src.Application.Interfaces;
using MathGame.src.Application.Utils.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.src.Application.Features.PlayFeature
{
    public class PlayFeatureHandler : IRequestHandler<PlayFeatureRequest, MessageResponse>
    {
        readonly IPlayerRepository _playerRepository;
        readonly IValidator<PlayFeatureRequest> _playValidator;
        public PlayFeatureHandler(IPlayerRepository playerRepository, IValidator<PlayFeatureRequest> playValidator)
        {
            _playerRepository = playerRepository;
            _playValidator = playValidator;
        }
        public async Task<MessageResponse> Handle(PlayFeatureRequest request, CancellationToken cancellationToken)
        {
            var responseMessage = _playValidator.ValidateAndHandleErrors(request);

            if (responseMessage.Code != 0)
                return responseMessage;

            await _playerRepository.CreateAsync(new Player(request.Name));

            return new MessageResponse("success", 0);
        }
    }
}
