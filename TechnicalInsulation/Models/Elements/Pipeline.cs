using TechnicalInsulation.Enums;
using TechnicalInsulation.Models.Dtos;

namespace TechnicalInsulation.Models.Elements;

public class Pipeline : Element
{
    public Pipeline()
    {
    }
    
    public Pipeline(Scope scope, PipelineType type, AddElementDto dto) : 
        base(dto.Drawing!, (int)dto.Number!, (decimal)dto.Temperature!, (decimal)dto.Length!, scope)
    {
        NominalDiameter = (int)dto.FirstDimension!;
        SecondaryDiameter = (int?)dto.SecondDimension;
        Angle = dto.Angle;
        PipelineType = type;
    }
    
    public int NominalDiameter { get; init; }
    public int? SecondaryDiameter { get; init; }
    public int? Angle { get; init; }
    public int PipelineTypeId { get; init; }
    public PipelineType PipelineType { get; init; } = null!;
}