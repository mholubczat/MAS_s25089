namespace TechnicalInsulation.Models.Workers;

public class Insulator
{
    public int WorkerId { get; init; }
    public Worker Worker { get; init; } = null!;
}