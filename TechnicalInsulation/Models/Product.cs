using TechnicalInsulation.Models.Elements;

namespace TechnicalInsulation.Models;

public class Product
{
    public int ProductId { get; init; }
    public decimal Area { get; init; }
    public string Drawing { get; init; } = null!;
    public int Number { get; init; }
    public Element Element { get; init; } = null!;
    public decimal Price { get; init; }
    public static int MaxInsulationThickness = 300;
}