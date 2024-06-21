namespace TechnicalInsulation.Models.Workers;

public class CostEstimator
{
    public int WorkerId { get; init; }
    public Worker Worker { get; init; } = null!;
}