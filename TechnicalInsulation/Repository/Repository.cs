using Microsoft.EntityFrameworkCore;
using TechnicalInsulation.Context;
using TechnicalInsulation.Models;
using TechnicalInsulation.Models.Elements;

namespace TechnicalInsulation.Repository;

public class Repository : IRepository
{
    private readonly TechnicalInsulationContext _context;

    public Repository(TechnicalInsulationContext context)
    {
        _context = context;
    }

    public async Task<Scope> GetScope(int scopeId, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Scopes
                .Include(scope => scope.Elements)
                .SingleAsync(scope => scope.ScopeId == scopeId, cancellationToken);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"Scope id {scopeId} not found");
        }
    }
    
    public async Task<PipelineType> GetPipelineType(string? pipelineType, CancellationToken cancellationToken)
    {
        if (pipelineType == null)
        {
            throw new NullReferenceException(nameof(PipelineType));
        }

        try
        {
            return await _context.PipelineTypes.SingleAsync(type => type.Name == pipelineType, cancellationToken);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"PipelineType {pipelineType} not found");
        }
    }
    
    public async Task<VesselBottom> GetVesselBottom(string? vesselBottom, CancellationToken cancellationToken)
    {
        if (vesselBottom == null)
        {
            throw new NullReferenceException(nameof(PipelineType));
        }

        try
        {
            return await _context.VesselBottoms.SingleAsync(type => type.Name == vesselBottom, cancellationToken);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"VesselBottom {vesselBottom} not found");
        }
    }

    public async Task Save(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}