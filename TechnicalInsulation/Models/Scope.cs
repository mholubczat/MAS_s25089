using TechnicalInsulation.Models.Elements;

namespace TechnicalInsulation.Models;

public sealed class Scope
{
    public int ScopeId { get; init; }
    public string Name { get; init; } = null!;
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public string Location { get; init; } = null!;
    public int MaxTemperatureOnInsulationJacket { get; init; }
    public int DesignAirTemperature { get; init; }
    public int DesignAirVelocity { get; init; }

    public int EnvironmentalCorrosivityCategoryId { get; init; }
    public ICollection<Element> Elements = new List<Element>();
    public EnvironmentalCorrosivityCategory EnvironmentalCorrosivityCategory { get; init; } = null!;
}