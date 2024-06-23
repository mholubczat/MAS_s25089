using TechnicalInsulation.Enums;
using TechnicalInsulation.Models.Dtos;

namespace TechnicalInsulation.Models.Elements;

public class Vessel : Element
{
    public Vessel()
    {
        
    }
    
    public Vessel(Scope scope, List<VesselBottom> vesselBottoms, AddElementDto dto) : 
        base(dto.Drawing!, (int)dto.Number!, (decimal)dto.Temperature!, (decimal)dto.Length!, scope)
    {
        VesselBottoms = vesselBottoms;
        Radius = (decimal)dto.FirstDimension!;
    }
    
    public decimal Radius { get; init; }
    public ICollection<Pipeline> Pipes { get; init; } = new List<Pipeline>();
    public ICollection<VesselBottom> VesselBottoms { get; set; } = new List<VesselBottom>();
}