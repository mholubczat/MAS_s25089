using Microsoft.AspNetCore.Mvc.ModelBinding;
using TechnicalInsulation.Enums;
using TechnicalInsulation.Models;
using TechnicalInsulation.Models.Dtos;
using TechnicalInsulation.Models.Elements;
using TechnicalInsulation.Repository;

namespace TechnicalInsulation.Service;

public class AddElementService : IAddElementService
{
    private readonly IRepository _repository;

    public AddElementService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task AddElement(int scopeId, AddElementDto dto, CancellationToken cancellationToken)
    {
        var scope = await _repository.GetScope(scopeId, cancellationToken);
        if (scope.Elements.Any(element => element.Drawing == dto.Drawing && element.Number == dto.Number))
        {
            throw new InvalidOperationException($"Element number {dto.Number} from drawing {dto.Drawing} already exists");  
        }
        
        switch (dto.SelectedElementType)
        {
            case nameof(Duct):
                await AddDuct(scope, dto, cancellationToken);
                break;
            case nameof(Vessel):
                await AddVessel(scope, dto, cancellationToken);
                break;
            case nameof(Pipeline):
                await AddPipeline(scope, dto, cancellationToken);
                break;
            default:
                throw new ArgumentOutOfRangeException(dto.SelectedElementType);
        }
    }

    private async Task AddPipeline(Scope scope, AddElementDto dto, CancellationToken cancellationToken)
    {
        var pipelineType = await _repository.GetPipelineType(dto.SelectedPipelineType, cancellationToken);
        var element = new Pipeline(scope, pipelineType, dto);
        await _repository.Save(cancellationToken);
    }

    private async Task AddVessel(Scope scope, AddElementDto dto, CancellationToken cancellationToken)
    {
      
        var vesselBottom = await _repository.GetVesselBottom(dto.SelectedVesselBottomType1, cancellationToken);
        var vesselBottoms = new List<VesselBottom> { vesselBottom };
        if (dto.SelectedVesselBottomType2 != null)
        {
            var secondVesselBottom = await _repository.GetVesselBottom(dto.SelectedVesselBottomType2, cancellationToken);
            vesselBottoms.Add(secondVesselBottom);
        }
        
        var element = new Vessel(scope, vesselBottoms, dto);
        await _repository.Save(cancellationToken);
    }

    private async Task AddDuct(Scope scope, AddElementDto dto, CancellationToken cancellationToken)
    {
        var element = new Duct(scope, dto);
        await _repository.Save(cancellationToken);
    }

    public void Validate(AddElementDto dto, ModelStateDictionary modelState)
    {
        switch (dto.SelectedElementType)
        {
            case nameof(Duct):
                ValidateDuct(dto, modelState);
                break;
            case nameof(Vessel):
                ValidateVessel(dto, modelState);
                break;
            case nameof(Pipeline):
                ValidatePipeline(dto, modelState);
                break;
        }
    }
    
    private static void ValidateDuct(AddElementDto dto, ModelStateDictionary modelState)
    {
        var tryParse = Enum.TryParse(dto.SelectedDuctType, out DuctType type);
        if (tryParse == false)
        {
            modelState.AddModelError(nameof(dto.SelectedDuctType), "Duct type is required");
        }

        if (type == DuctType.Rectangular && dto.SecondDimension is not > 0)
        {
            modelState.AddModelError(nameof(dto.SecondDimension), "Positive second dimension is required");
        }
    }

    private static void ValidateVessel(AddElementDto dto, ModelStateDictionary modelState)
    {
        var tryParse = Enum.TryParse(dto.SelectedVesselBottomType1, out VesselBottomEnum _);
        if (tryParse == false)
        {
            modelState.AddModelError(nameof(dto.SelectedVesselBottomType1), "Vessel has at least one bottom");
        }
    }

    private static void ValidatePipeline(AddElementDto dto, ModelStateDictionary modelState)
    {
        var tryParse = Enum.TryParse(dto.SelectedPipelineType, out PipelineTypeEnum type);
        if (tryParse == false)
        {
            modelState.AddModelError(nameof(dto.SelectedPipelineType), "Pipeline type is required");
        }
        
        if (type == PipelineTypeEnum.Elbow && dto.Angle is not > 0)
        {
            modelState.AddModelError(nameof(dto.Angle), "Positive angle is required");
        }
        
        if (type is PipelineTypeEnum.Reduction or PipelineTypeEnum.Tee && dto.SecondDimension is not > 0)
        {
            modelState.AddModelError(nameof(dto.SecondDimension), "Positive second dimension is required");
        }
    }
}