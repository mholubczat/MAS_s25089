namespace TechnicalInsulation.Models.Elements;

public class Vessel : Element
{
    public Vessel()
    {
        
    }
    
    public Vessel(decimal length, Scope scope, decimal temperature, string drawing, int number, decimal radius) :
        base(drawing, number, temperature, length, scope)
    {
        Radius = radius;
    } 

    public decimal Radius { get; init; }
    public ICollection<Pipeline> Pipes { get; init; } = new List<Pipeline>();
    public ICollection<VesselBottom> VesselBottoms { get; init; } = new List<VesselBottom>();
}