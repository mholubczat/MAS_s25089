namespace TechnicalInsulation.Models.Materials;

public class Insulation
{
    public int MaxTemperature { get; init; }
    public decimal ThermalConductivityCoefficient { get; init; }
    public int? WiringId { get; init; }
    public Wiring? Wiring { get; init; }
    public int MaterialId { get; init; }
    public Material Material { get; init; } = null!;
}