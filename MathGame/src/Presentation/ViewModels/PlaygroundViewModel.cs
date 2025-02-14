global using MathGame.src.Application.Features.PlayFeature;
global using MediatR;
using FluentValidation;
using System.Threading.Tasks;

namespace MathGame.src.Presentation.ViewModels;

public partial class PlaygroundViewModel : BaseViewModel
{
    readonly IMediator _mediator;
    public PlaygroundViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [RelayCommand]
    async Task Add(PlayFeatureRequest featureRequest)
    {
        if (featureRequest == null) { }

        var response = await _mediator.Send(featureRequest!);

        if (response.ShowMessageAndStopExecution())
            return;

    }
}
