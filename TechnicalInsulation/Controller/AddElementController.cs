using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TechnicalInsulation.Components.Pages;
using TechnicalInsulation.Enums;
using TechnicalInsulation.Models.Dtos;
using TechnicalInsulation.Models.Elements;
using TechnicalInsulation.Service;

namespace TechnicalInsulation.Controller;

[Route("add-element/")]
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
    public IActionResult Save([FromBody] AddElementDto dto)
    {
        var validationResult = _addElementService.Validate(dto);
        if (validationResult == false)
        {
            return BadRequest("Invalid data");
        }
        
        Console.WriteLine(dto);
        return Created();
    }
}