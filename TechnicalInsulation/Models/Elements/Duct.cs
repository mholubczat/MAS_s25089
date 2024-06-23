using TechnicalInsulation.Enums;
using TechnicalInsulation.Models.Dtos;

namespace TechnicalInsulation.Models.Elements;

public class Duct : Element
{
    public Duct()
    {
    }
    
    public Duct(Scope scope, AddElementDto dto) : 
        base(dto.Drawing!, (int)dto.Number!, (decimal)dto.Temperature!, (decimal)dto.Length!, scope)
    {
        FirstDimension = (decimal)dto.FirstDimension!;
        SecondDimension = dto.SecondDimension;
    }

    public Duct(decimal length, Scope scope, decimal temperature, string drawing, int number, decimal firstDimension, decimal? secondDimension) :
        base(drawing, number, temperature, length, scope)
    {
        FirstDimension = firstDimension;
        SecondDimension = secondDimension;
    }
    
    public decimal FirstDimension { get; init; }
    public decimal? SecondDimension { get; init; }
    public DuctType DuctType => SecondDimension == null ? DuctType.Round : DuctType.Rectangular;
}