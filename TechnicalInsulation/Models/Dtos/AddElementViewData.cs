namespace TechnicalInsulation.Models.Dtos;

public class AddElementViewData
{
    public List<string> ElementTypes { get; init; } = [];
    public List<string> DuctTypes { get; init; } = [];
    public List<string> PipelineTypes { get; init; } = [];
    public List<string> VesselBottomTypes { get; init; } = [];
}