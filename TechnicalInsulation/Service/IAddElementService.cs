using TechnicalInsulation.Models.Dtos;

namespace TechnicalInsulation.Service;

public interface IAddElementService
{
    public bool Validate(AddElementDto dto);
}