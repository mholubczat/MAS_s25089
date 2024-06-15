using System.ComponentModel.DataAnnotations;

namespace TechnicalInsulation.Models;

public class EnvironmentalCorrosivityCategory
{
    public int Id { get; init; }
    [MaxLength(3)]
    public string Name { get; init; } = null!;
}