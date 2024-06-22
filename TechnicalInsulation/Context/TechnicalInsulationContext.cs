using Microsoft.EntityFrameworkCore;
using TechnicalInsulation.Enums;
using TechnicalInsulation.Models;
using TechnicalInsulation.Models.Elements;
using TechnicalInsulation.Models.Materials;
using TechnicalInsulation.Models.Workers;

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
                .HasForeignKey(e => e.EnvironmentalCorrosivityCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

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
                .HasForeignKey(e => e.PipelineTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
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

            entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
            entity.Property(e => e.Area);
            entity.Property(e => e.Price);

            entity.HasOne<Element>(e => e.Element)
                .WithOne(c => c.Product)
                .HasForeignKey<Product>(e => new { e.Drawing, e.Number })
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany<Production>(e => e.InsulationProductions)
                .WithOne(c => c.Product)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            entity.HasMany<Material>(e => e.Materials)
                .WithOne()
                .HasForeignKey(e => e.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        
        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PK_Worker");
            entity.ToTable(nameof(Worker), Schema);

            entity.Property(e => e.WorkerId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.HiredOn);
            entity.Property(e => e.Wage);
            
            entity.HasMany<Production>(e => e.InsulationProductions)
                .WithOne(c => c.Worker)
                .HasForeignKey(e => e.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne<Insulator>(e => e.Insulator)
                .WithOne()
                .HasForeignKey<Insulator>(e => e.WorkerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<CostEstimator>(e => e.CostEstimator)
                .WithOne()
                .HasForeignKey<CostEstimator>(e => e.WorkerId)
                .OnDelete(DeleteBehavior.Cascade);
        }); 
        
        modelBuilder.Entity<Insulator>(entity =>
        {
            entity.HasKey(e => e.WorkerId);
            entity.ToTable(nameof(Insulator), Schema);
            
            entity.HasOne(e => e.Worker)
                .WithOne(e => e.Insulator)
                .HasForeignKey<Insulator>(e => e.WorkerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CostEstimator>(entity =>
        {
            entity.HasKey(e => e.WorkerId);
            entity.ToTable(nameof(CostEstimator), Schema);
            
            entity.HasOne(e => e.Worker)
                .WithOne(e => e.CostEstimator)
                .HasForeignKey<CostEstimator>(e => e.WorkerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.WorkerId }).HasName("PK_Production");
            entity.ToTable(nameof(Production), Schema);

            entity.Property(e => e.EstimatedWorkload).IsRequired(false);
            entity.Property(e => e.ActualWorkload).IsRequired(false);
        });
        
        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK_Material");
            entity.ToTable(nameof(Material), Schema);

            entity.Property(e => e.MaterialId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Density);
            entity.Property(e => e.Thickness);
            entity.Property(e => e.PricePerSquareMeter).IsRequired(false);
            entity.Property(e => e.PricePerCubicMeter).IsRequired(false);

            entity.HasOne<Insulation>(e => e.Insulation)
                .WithOne()
                .HasForeignKey<Insulation>(e => e.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne<Casing>(e => e.Casing)
                .WithOne()
                .HasForeignKey<Casing>(e => e.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Insulation>(entity =>
        {
            entity.HasKey(e => e.MaterialId);
            entity.ToTable(nameof(Insulation), Schema);
            
            entity.Property(e => e.MaxTemperature);
            entity.Property(e => e.ThermalConductivityCoefficient);
            
            entity.HasOne<Material>(e => e.Material)
                .WithOne(m => m.Insulation)
                .HasForeignKey<Insulation>(e => e.MaterialId);

            entity.HasOne<Wiring>()
                .WithMany()
                .HasForeignKey(e => e.WiringId);
        });
        
        modelBuilder.Entity<Casing>(entity =>
        {
            entity.HasKey(e => e.MaterialId);
            entity.ToTable(nameof(Casing), Schema);
            
            entity.HasOne<Material>(e => e.Material)
                .WithOne(m => m.Casing)
                .HasForeignKey<Casing>(e => e.MaterialId);


            entity.HasOne<EnvironmentalCorrosivityCategory>()
                .WithMany()
                .HasForeignKey(e => e.EnvironmentalCorrosivityCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            entity.HasOne<Profile>()
                .WithMany()
                .HasForeignKey(e => e.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        
        modelBuilder.Entity<Wiring>(entity =>
        {
            entity.HasKey(e => e.WiringId).HasName("PK_Wiring");
            entity.ToTable(nameof(Wiring), Schema);

            entity.Property(e => e.WiringId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);

            entity.HasData(Enum.GetValues(typeof(WiringEnum))
                .Cast<WiringEnum>()
                .Select(s =>
                    new Wiring
                    {
                        WiringId = (int)s + 1,
                        Name = s.ToString()
                    })
            );
        });
        
        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK_Profile");
            entity.ToTable(nameof(Profile), Schema);

            entity.Property(e => e.ProfileId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);

            entity.HasData(Enum.GetValues(typeof(ProfileEnum))
                .Cast<ProfileEnum>()
                .Select(s =>
                    new Profile
                    {
                        ProfileId = (int)s + 1,
                        Name = s.ToString()
                    })
            );
        });
    }
}