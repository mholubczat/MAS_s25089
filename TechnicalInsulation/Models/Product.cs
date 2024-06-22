using System.ComponentModel.DataAnnotations;
using TechnicalInsulation.Models.Elements;
using TechnicalInsulation.Models.Materials;

namespace TechnicalInsulation.Models;

public class Product
{
    public int ProductId { get; init; }
    public decimal Area { get; init; }
    [MaxLength(100)]
    public string Drawing { get; init; } = null!;
    public int Number { get; init; }
    public Element Element { get; init; } = null!;
    public decimal Price { get; init; }
    public ICollection<Production> InsulationProductions { get; init; } = new List<Production>();
    public ICollection<Material> Materials { get; init; } = new List<Material>();
}