using System.ComponentModel.DataAnnotations;

namespace TechnicalInsulation.Models.Dtos;

public class AddElementDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Number must be greater than 0")]
    public int? Number { get; set; }

    [Required]
    public string? Drawing { get; set; } = null!;
    
    [Required]
    public string? SelectedElementType { get; set; } = null!;

    public string? SelectedDuctType { get; set; } = null!;
    public string? SelectedPipelineType { get; set; } = null!;
    public string? SelectedVesselBottomType1 { get; set; } = null!;
    public string? SelectedVesselBottomType2 { get; set; } = null!;
    
    [Required]
    public decimal? Temperature { get; set; }

    [Required]
    [Range(0.01, int.MaxValue, ErrorMessage = "Number must be greater than 0")]
    public decimal? Length { get; set; }
    
    [Required]
    [Range(0.01, int.MaxValue, ErrorMessage = "Number must be greater than 0")]
    public decimal? FirstDimension { get; set; }
    public decimal? SecondDimension { get; set; }
    public int? Angle { get; set; }
}