using Microsoft.AspNetCore.Mvc.ModelBinding;
using TechnicalInsulation.Models.Dtos;

namespace TechnicalInsulation.Service;

public interface IAddElementService
{
    public void Validate(AddElementDto dto, ModelStateDictionary modelState);
    Task AddElement(int scopeId, AddElementDto dto, CancellationToken cancellationToke);
}