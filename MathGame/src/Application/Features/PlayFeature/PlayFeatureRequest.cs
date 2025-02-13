using System.ComponentModel.DataAnnotations;

namespace MathGame.src.Application.Features.PlayFeature;

public class PlayFeatureRequest : IRequest<MessageResponse>
{
    public string Name { get; set; }
}
