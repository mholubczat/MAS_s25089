namespace TechnicalInsulation.Models.Materials;

public class Casing
{
    public int EnvironmentalCorrosivityCategoryId { get; init; }
    public EnvironmentalCorrosivityCategory MaxEnvironmentalCorrosivityCategory { get; init; } = null!;
    public int ProfileId { get; init; }
    public Profile Profile { get; init; } = null!;
    public int MaterialId { get; init; }
    public Material Material { get; init; } = null!;
}