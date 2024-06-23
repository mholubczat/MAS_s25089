using TechnicalInsulation.Enums;

namespace TechnicalInsulation.Models.Elements;

public class PipelineType
{
    public PipelineType()
    {
    }

    public int PipelineTypeId { get; init; }
    public string Name { get; init; } = null!;
}