namespace TechnicalInsulation.Models.Workers;

public class Worker
{
    public int WorkerId { get; init; }
    public string Name { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public DateTime HiredOn { get; init; }
    public decimal Wage { get; init; }
    public ICollection<Production> InsulationProductions { get; init; } = new List<Production>();
    public Insulator? Insulator { get; init; }
    public CostEstimator? CostEstimator { get; init; }
}