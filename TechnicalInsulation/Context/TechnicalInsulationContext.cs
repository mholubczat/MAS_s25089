using Microsoft.EntityFrameworkCore;
using TechnicalInsulation.Enums;
using TechnicalInsulation.Models;
using TechnicalInsulation.Models.Elements;

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
    public DbSet<Element> Elements { get; init; }

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
                .HasForeignKey(e => e.EnvironmentalCorrosivityCategoryId);

            entity.HasMany(e => e.Elements)
                .WithOne(c => c.Scope)
                .HasForeignKey(e => e.ScopeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EnvironmentalCorrosivityCategory>(entity =>
        {
            entity.HasKey(e => e.EnvironmentalCorrosivityCategoryId).HasName("PK_EnvironmentalCorrosivityCategory");
            entity.ToTable(nameof(EnvironmentalCorrosivityCategory), Schema);

            entity.Property(e => e.EnvironmentalCorrosivityCategoryId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(3);

            entity.HasData(Enum.GetValues(typeof(EnvironmentalCorrosivityCategoryEnum))
                .Cast<EnvironmentalCorrosivityCategoryEnum>()
                .Select(s =>
                    new EnvironmentalCorrosivityCategory
                    {
                        EnvironmentalCorrosivityCategoryId = (int)s + 1,
                        Name = s.ToString()
                    })
            );
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.HasKey(e => new { e.Drawing, e.Number }).HasName("PK_Element");
            entity.ToTable(nameof(Element), Schema);

            entity.Property(e => e.Drawing).HasMaxLength(100);
            entity.Property(e => e.Number);
            entity.Property(e => e.Length);
            entity.Property(e => e.Temperature);

            entity.HasIndex(e => new { e.Drawing, e.Number }).IsUnique();

            entity.HasDiscriminator<string>("ElementType")
                .HasValue<Duct>("Duct")
                .HasValue<Vessel>("Vessel")
                .HasValue<Pipeline>("Pipeline");
        });

        modelBuilder.Entity<Duct>(entity =>
        {
            entity.Property(e => e.FirstDimension);
            entity.Property(e => e.SecondDimension).IsRequired(false);
        });

        modelBuilder.Entity<Vessel>(entity =>
        {
            entity.Property(e => e.Radius);
            entity.HasMany<Pipeline>(e => e.Pipes);
            entity.HasMany<VesselBottom>(e => e.VesselBottoms);
        });

        modelBuilder.Entity<Pipeline>(entity =>
        {
            entity.Property(e => e.NominalDiameter);
            entity.Property(e => e.SecondaryDiameter).IsRequired(false);
            entity.Property(e => e.Angle).IsRequired(false);

            entity.HasOne(e => e.PipelineType)
                .WithMany()
                .HasForeignKey(e => e.PipelineTypeId);
        });

        modelBuilder.Entity<VesselBottom>(entity =>
        {
            entity.HasKey(e => e.VesselBottomId).HasName("PK_VesselBottom");
            entity.ToTable(nameof(VesselBottom), Schema);

            entity.Property(e => e.VesselBottomId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);

            entity.HasData(Enum.GetValues(typeof(VesselBottomEnum))
                .Cast<VesselBottomEnum>()
                .Select(s =>
                    new VesselBottom
                    {
                        VesselBottomId = (int)s + 1,
                        Name = s.ToString()
                    })
            );
        });

        modelBuilder.Entity<PipelineType>(entity =>
        {
            entity.HasKey(e => e.PipelineTypeId).HasName("PK_PipelineType");
            entity.ToTable(nameof(PipelineType), Schema);

            entity.Property(e => e.PipelineTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);

            entity.HasData(Enum.GetValues(typeof(PipelineTypeEnum))
                .Cast<PipelineTypeEnum>()
                .Select(s =>
                    new PipelineType
                    {
                        PipelineTypeId = (int)s + 1,
                        Name = s.ToString()
                    })
            );
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product");
            entity.ToTable(nameof(Product), Schema);

            entity.Property(e => e.Area);
            entity.Property(e => e.Price);

            entity.HasOne<Element>(e => e.Element)
                .WithOne(c => c.Product)
                .HasForeignKey<Product>(e => new { e.Drawing, e.Number })
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}