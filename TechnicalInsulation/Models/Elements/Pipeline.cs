namespace TechnicalInsulation.Models.Elements;

public class Pipeline : Element
{
    public Pipeline()
    {
        
    }
    
    public Pipeline(string drawing, int number, decimal temperature, decimal length, Scope scope, int nominalDiameter, int? secondaryDiameter, int? angle, PipelineType pipelineType) : 
        base(drawing, number, temperature, length, scope)
    {
        NominalDiameter = nominalDiameter;
        SecondaryDiameter = secondaryDiameter;
        Angle = angle;
        PipelineType = pipelineType;
    }
    
    public int NominalDiameter { get; init; }
    public int? SecondaryDiameter { get; init; }
    public int? Angle { get; init; }
    public int PipelineTypeId { get; init; }
    public PipelineType PipelineType { get; init; } = null!;
}