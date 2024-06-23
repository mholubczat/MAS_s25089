using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TechnicalInsulation.Enums;
using TechnicalInsulation.Models.Dtos;
using TechnicalInsulation.Models.Elements;
using TechnicalInsulation.Service;

namespace TechnicalInsulation.Controller;

[Route("{scopeId:int}/add-element/")]
public class AddElementController : ControllerBase
{
    private readonly IAddElementService _addElementService;

    public AddElementController(IAddElementService addElementService)
    {
        _addElementService = addElementService;
    }

    [HttpGet("load-view-data")]
    public IActionResult LoadViewData()
    {
        var elementTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => typeof(Element).IsAssignableFrom(type) && type != typeof(Element))
            .Select(type => type.Name)
            .ToList();

        var ductTypes  = Enum.GetValues(typeof(DuctType))
            .Cast<DuctType>()
            .Select(e => e.ToString())
            .ToList(); 

        var pipelineTypes = Enum.GetValues(typeof(PipelineTypeEnum))
            .Cast<PipelineTypeEnum>()
            .Select(e => e.ToString())
            .ToList();

        var vesselBottomTypes = Enum.GetValues(typeof(VesselBottomEnum))
            .Cast<VesselBottomEnum>()
            .Select(e => e.ToString())
            .ToList();

        var data = new AddElementViewData
        {
            ElementTypes = elementTypes,
            DuctTypes = ductTypes,
            PipelineTypes = pipelineTypes,
            VesselBottomTypes = vesselBottomTypes
        };

        return Ok(data);
    }
    
    [HttpPost("save")]
    public async Task<IActionResult> Save([FromBody] AddElementDto dto, CancellationToken cancellationToken, int scopeId)
    {
        _addElementService.Validate(dto, ModelState);
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            await _addElementService.AddElement(scopeId, dto, cancellationToken);
        }
        catch (Exception exception)
        {
            ModelState.AddModelError(nameof(dto.Drawing), exception.Message);
            return BadRequest(exception.Message);
        }
        
        return Created();
    }
}

