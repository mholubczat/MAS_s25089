namespace TechnicalInsulation.Models.Dtos;

public class AddElementDto
{
    public int? Number { get; set; }
    public string Drawing { get; set; } = null!;
    public string SelectedElementType { get; set; } = null!;
    public string SelectedDuctType { get; set; } = null!;
    public string SelectedPipelineType { get; set; } = null!;
    public string SelectedVesselBottomType1 { get; set; } = null!;
    public string SelectedVesselBottomType2 { get; set; } = null!;
    public decimal? Temperature { get; set; }
    public decimal? Length { get; set; }
    public decimal? FirstDimension { get; set; }
    public decimal? SecondDimension { get; set; }
    public int? Angle { get; set; }
}