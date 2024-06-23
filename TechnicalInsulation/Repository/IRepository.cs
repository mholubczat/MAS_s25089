using TechnicalInsulation.Models;
using TechnicalInsulation.Models.Elements;

namespace TechnicalInsulation.Repository;

public interface IRepository
{
    Task<Scope> GetScope(int scopeId, CancellationToken cancellationToken);
    Task<PipelineType> GetPipelineType(string? dtoSelectedPipelineType, CancellationToken cancellationToken);
    Task<VesselBottom> GetVesselBottom(string? dtoSelectedPipelineType, CancellationToken cancellationToken);
    Task Save(CancellationToken cancellationToken);
}