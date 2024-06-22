using System.ComponentModel.DataAnnotations;

namespace TechnicalInsulation.Models.Materials;

public class Material
{
    public int MaterialId { get; init; }
    [MaxLength(200)] public string Name { get; init; } = null!;
    
    public decimal Thickness { get; init; }
    
    public decimal Density { get; init; }
    
    public decimal? PricePerSquareMeter { get; init; }
    
    public decimal? PricePerCubicMeter { get; init; }
    public decimal WeightPerSquareMeter => Thickness * Density;

    public Insulation? Insulation { get; init; }
    public Casing? Casing { get; init; }
}