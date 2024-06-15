using Microsoft.EntityFrameworkCore;
using TechnicalInsulation.Enums;
using TechnicalInsulation.Models;

namespace TechnicalInsulation.Context;

public class TechnicalInsulationContext : DbContext
{
    private const string Schema = "mas";
    public TechnicalInsulationContext()
    {
    }

    public TechnicalInsulationContext(DbContextOptions<TechnicalInsulationContext> options)
        : base(options)
    {
    }

    public DbSet<Scope> Scopes { get; init; }
    public DbSet<EnvironmentalCorrosivityCategory> CorrosivityCategories { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Scope>(entity =>
        {
            entity.HasKey(e => e.ScopeId).HasName("PK_Scope");

            entity.ToTable(nameof(Scope), Schema);

            entity.Property(e => e.ScopeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Start);
            entity.Property(e => e.End);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.MaxTemperatureOnInsulationJacket);
            entity.Property(e => e.DesignAirTemperature);
            entity.Property(e => e.DesignAirVelocity);

            entity.HasOne(e => e.EnvironmentalCorrosivityCategory)
                .WithMany()
                .HasForeignKey(e => e.EnvironmentalCorrosivityCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EnvironmentalCorrosivityCategory>()
            .HasData(Enum.GetValues(typeof(EnvironmentalCorrosivityCategoryEnum))
                .Cast<EnvironmentalCorrosivityCategoryEnum>()
                .Select(s => new { Id = (int)s + 1, Name = s.ToString() })
            );
    }
}