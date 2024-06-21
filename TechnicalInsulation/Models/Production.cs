using TechnicalInsulation.Models.Workers;

namespace TechnicalInsulation.Models;

public class Production
{
    public decimal? EstimatedWorkload { get; init; }
    public decimal? ActualWorkload { get; init; }
    public int WorkerId { get; init; }
    public Worker Worker { get; init; }
    public int ProductId { get; init; }
    public Product Product { get; init; }
}