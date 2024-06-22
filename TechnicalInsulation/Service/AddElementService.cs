using TechnicalInsulation.Enums;
using TechnicalInsulation.Models.Dtos;
using TechnicalInsulation.Models.Elements;

namespace TechnicalInsulation.Service;

public class AddElementService : IAddElementService
{
    public bool Validate(AddElementDto dto)
    {
        return ValidateBase(dto) && dto.SelectedElementType switch
        {
            nameof(Duct) => ValidateDuct(dto),
            nameof(Vessel) => ValidateVessel(dto),
            nameof(Pipeline) => ValidatePipeline(dto),
            _ => false
        };
    }

    private static bool ValidateBase(AddElementDto dto)
    {
        return dto is { Number: > 0, Temperature: not null, Length: > 0, FirstDimension: > 0 } 
            && string.IsNullOrEmpty(dto.Drawing) == false;
    }

    private static bool ValidateDuct(AddElementDto dto)
    {
        var tryParse = Enum.TryParse(dto.SelectedDuctType, out DuctType type);
        return tryParse && type switch
        {
            DuctType.Round => true,
            DuctType.Rectangular => dto.SecondDimension is > 0,
            _ => throw new ArgumentOutOfRangeException($"Unexpected duct type {dto.SelectedDuctType}")
        };
    }

    private static bool ValidateVessel(AddElementDto dto)
    {
        return Enum.TryParse(dto.SelectedVesselBottomType1, out VesselBottomEnum _);
    }

    private static bool ValidatePipeline(AddElementDto dto)
    {
        var tryParse = Enum.TryParse(dto.SelectedPipelineType, out PipelineTypeEnum type);
        return tryParse && type switch
        {
            PipelineTypeEnum.Pipe => true,
            PipelineTypeEnum.Valve => true,
            PipelineTypeEnum.Cap => true,
            PipelineTypeEnum.Elbow => dto.Angle is > 0,
            PipelineTypeEnum.Reduction => dto.SecondDimension is > 0,
            PipelineTypeEnum.Tee => dto.SecondDimension is > 0,
            _ => throw new ArgumentOutOfRangeException($"Unexpected pipeline type {dto.SelectedPipelineType}")
        };
    }
}