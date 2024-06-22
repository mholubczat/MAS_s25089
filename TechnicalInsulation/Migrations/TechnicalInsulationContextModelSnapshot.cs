﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalInsulation.Context;

#nullable disable

namespace TechnicalInsulation.Migrations
{
    [DbContext(typeof(TechnicalInsulationContext))]
    partial class TechnicalInsulationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Element", b =>
                {
                    b.Property<string>("Drawing")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("ElementType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ScopeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Drawing", "Number")
                        .HasName("PK_Element");

                    b.HasIndex("ScopeId");

                    b.HasIndex("Drawing", "Number")
                        .IsUnique();

                    b.ToTable("Element", "mas");

                    b.HasDiscriminator<string>("ElementType").HasValue("Element");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.PipelineType", b =>
                {
                    b.Property<int>("PipelineTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PipelineTypeId")
                        .HasName("PK_PipelineType");

                    b.ToTable("PipelineType", "mas");

                    b.HasData(
                        new
                        {
                            PipelineTypeId = 1,
                            Name = "Pipe"
                        },
                        new
                        {
                            PipelineTypeId = 2,
                            Name = "Valve"
                        },
                        new
                        {
                            PipelineTypeId = 3,
                            Name = "Elbow"
                        },
                        new
                        {
                            PipelineTypeId = 4,
                            Name = "Tee"
                        },
                        new
                        {
                            PipelineTypeId = 5,
                            Name = "Reduction"
                        },
                        new
                        {
                            PipelineTypeId = 6,
                            Name = "Cap"
                        });
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.VesselBottom", b =>
                {
                    b.Property<int>("VesselBottomId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VesselDrawing")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("VesselNumber")
                        .HasColumnType("int");

                    b.HasKey("VesselBottomId")
                        .HasName("PK_VesselBottom");

                    b.HasIndex("VesselDrawing", "VesselNumber");

                    b.ToTable("VesselBottom", "mas");

                    b.HasData(
                        new
                        {
                            VesselBottomId = 1,
                            Name = "Flat"
                        },
                        new
                        {
                            VesselBottomId = 2,
                            Name = "Sphere"
                        },
                        new
                        {
                            VesselBottomId = 3,
                            Name = "Zeppelin"
                        },
                        new
                        {
                            VesselBottomId = 4,
                            Name = "Cone"
                        });
                });

            modelBuilder.Entity("TechnicalInsulation.Models.EnvironmentalCorrosivityCategory", b =>
                {
                    b.Property<int>("EnvironmentalCorrosivityCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("EnvironmentalCorrosivityCategoryId")
                        .HasName("PK_EnvironmentalCorrosivityCategory");

                    b.ToTable("EnvironmentalCorrosivityCategory", "mas");

                    b.HasData(
                        new
                        {
                            EnvironmentalCorrosivityCategoryId = 1,
                            Name = "C1"
                        },
                        new
                        {
                            EnvironmentalCorrosivityCategoryId = 2,
                            Name = "C2"
                        },
                        new
                        {
                            EnvironmentalCorrosivityCategoryId = 3,
                            Name = "C3"
                        },
                        new
                        {
                            EnvironmentalCorrosivityCategoryId = 4,
                            Name = "C4"
                        },
                        new
                        {
                            EnvironmentalCorrosivityCategoryId = 5,
                            Name = "C5I"
                        },
                        new
                        {
                            EnvironmentalCorrosivityCategoryId = 6,
                            Name = "C5M"
                        });
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Casing", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("EnvironmentalCorrosivityCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId1")
                        .HasColumnType("int");

                    b.HasKey("MaterialId");

                    b.HasIndex("EnvironmentalCorrosivityCategoryId");

                    b.HasIndex("MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ProfileId1");

                    b.ToTable("Casing", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Insulation", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("MaxTemperature")
                        .HasColumnType("int");

                    b.Property<decimal>("ThermalConductivityCoefficient")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("WiringId")
                        .HasColumnType("int");

                    b.Property<int?>("WiringId1")
                        .HasColumnType("int");

                    b.HasKey("MaterialId");

                    b.HasIndex("WiringId");

                    b.HasIndex("WiringId1");

                    b.ToTable("Insulation", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Density")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("PricePerCubicMeter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PricePerSquareMeter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Thickness")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaterialId")
                        .HasName("PK_Material");

                    b.ToTable("Material", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ProfileId")
                        .HasName("PK_Profile");

                    b.ToTable("Profile", "mas");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            Name = "Flat"
                        },
                        new
                        {
                            ProfileId = 2,
                            Name = "Trapezoid"
                        },
                        new
                        {
                            ProfileId = 3,
                            Name = "Diagonal"
                        },
                        new
                        {
                            ProfileId = 4,
                            Name = "Perforated"
                        });
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Wiring", b =>
                {
                    b.Property<int>("WiringId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("WiringId")
                        .HasName("PK_Wiring");

                    b.ToTable("Wiring", "mas");

                    b.HasData(
                        new
                        {
                            WiringId = 1,
                            Name = "Galvanized"
                        },
                        new
                        {
                            WiringId = 2,
                            Name = "Stainless"
                        });
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Drawing")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId")
                        .HasName("PK_Product");

                    b.HasIndex("Drawing", "Number")
                        .IsUnique();

                    b.ToTable("Product", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Production", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.Property<decimal?>("ActualWorkload")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EstimatedWorkload")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId", "WorkerId")
                        .HasName("PK_Production");

                    b.HasIndex("WorkerId");

                    b.ToTable("Production", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Scope", b =>
                {
                    b.Property<int>("ScopeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScopeId"));

                    b.Property<int>("DesignAirTemperature")
                        .HasColumnType("int");

                    b.Property<int>("DesignAirVelocity")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnvironmentalCorrosivityCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaxTemperatureOnInsulationJacket")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("ScopeId")
                        .HasName("PK_Scope");

                    b.HasIndex("EnvironmentalCorrosivityCategoryId");

                    b.ToTable("Scope", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Workers.CostEstimator", b =>
                {
                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("WorkerId");

                    b.ToTable("CostEstimator", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Workers.Insulator", b =>
                {
                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("WorkerId");

                    b.ToTable("Insulator", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Workers.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"));

                    b.Property<DateTime>("HiredOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Wage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("WorkerId")
                        .HasName("PK_Worker");

                    b.ToTable("Worker", "mas");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Duct", b =>
                {
                    b.HasBaseType("TechnicalInsulation.Models.Elements.Element");

                    b.Property<decimal>("FirstDimension")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SecondDimension")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Duct");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Pipeline", b =>
                {
                    b.HasBaseType("TechnicalInsulation.Models.Elements.Element");

                    b.Property<int?>("Angle")
                        .HasColumnType("int");

                    b.Property<int>("NominalDiameter")
                        .HasColumnType("int");

                    b.Property<int>("PipelineTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondaryDiameter")
                        .HasColumnType("int");

                    b.Property<string>("VesselDrawing")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("VesselNumber")
                        .HasColumnType("int");

                    b.HasIndex("PipelineTypeId");

                    b.HasIndex("VesselDrawing", "VesselNumber");

                    b.HasDiscriminator().HasValue("Pipeline");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Vessel", b =>
                {
                    b.HasBaseType("TechnicalInsulation.Models.Elements.Element");

                    b.Property<decimal>("Radius")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Vessel");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Element", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Scope", "Scope")
                        .WithMany("Elements")
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scope");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.VesselBottom", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Elements.Vessel", null)
                        .WithMany("VesselBottoms")
                        .HasForeignKey("VesselDrawing", "VesselNumber");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Casing", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.EnvironmentalCorrosivityCategory", null)
                        .WithMany()
                        .HasForeignKey("EnvironmentalCorrosivityCategoryId")
                        .IsRequired();

                    b.HasOne("TechnicalInsulation.Models.Materials.Material", "Material")
                        .WithOne("Casing")
                        .HasForeignKey("TechnicalInsulation.Models.Materials.Casing", "MaterialId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TechnicalInsulation.Models.EnvironmentalCorrosivityCategory", "MaxEnvironmentalCorrosivityCategory")
                        .WithMany()
                        .HasForeignKey("MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalInsulation.Models.Materials.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .IsRequired();

                    b.HasOne("TechnicalInsulation.Models.Materials.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("MaxEnvironmentalCorrosivityCategory");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Insulation", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Materials.Material", "Material")
                        .WithOne("Insulation")
                        .HasForeignKey("TechnicalInsulation.Models.Materials.Insulation", "MaterialId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TechnicalInsulation.Models.Materials.Wiring", null)
                        .WithMany()
                        .HasForeignKey("WiringId");

                    b.HasOne("TechnicalInsulation.Models.Materials.Wiring", "Wiring")
                        .WithMany()
                        .HasForeignKey("WiringId1");

                    b.Navigation("Material");

                    b.Navigation("Wiring");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Material", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Product", null)
                        .WithMany("Materials")
                        .HasForeignKey("MaterialId")
                        .IsRequired();
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Product", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Elements.Element", "Element")
                        .WithOne("Product")
                        .HasForeignKey("TechnicalInsulation.Models.Product", "Drawing", "Number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Production", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Product", "Product")
                        .WithMany("InsulationProductions")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.HasOne("TechnicalInsulation.Models.Workers.Worker", "Worker")
                        .WithMany("InsulationProductions")
                        .HasForeignKey("WorkerId")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Scope", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.EnvironmentalCorrosivityCategory", "EnvironmentalCorrosivityCategory")
                        .WithMany()
                        .HasForeignKey("EnvironmentalCorrosivityCategoryId")
                        .IsRequired();

                    b.Navigation("EnvironmentalCorrosivityCategory");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Workers.CostEstimator", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Workers.Worker", "Worker")
                        .WithOne("CostEstimator")
                        .HasForeignKey("TechnicalInsulation.Models.Workers.CostEstimator", "WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Workers.Insulator", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Workers.Worker", "Worker")
                        .WithOne("Insulator")
                        .HasForeignKey("TechnicalInsulation.Models.Workers.Insulator", "WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Pipeline", b =>
                {
                    b.HasOne("TechnicalInsulation.Models.Elements.PipelineType", "PipelineType")
                        .WithMany()
                        .HasForeignKey("PipelineTypeId")
                        .IsRequired();

                    b.HasOne("TechnicalInsulation.Models.Elements.Vessel", null)
                        .WithMany("Pipes")
                        .HasForeignKey("VesselDrawing", "VesselNumber");

                    b.Navigation("PipelineType");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Element", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Materials.Material", b =>
                {
                    b.Navigation("Casing");

                    b.Navigation("Insulation");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Product", b =>
                {
                    b.Navigation("InsulationProductions");

                    b.Navigation("Materials");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Scope", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Workers.Worker", b =>
                {
                    b.Navigation("CostEstimator");

                    b.Navigation("InsulationProductions");

                    b.Navigation("Insulator");
                });

            modelBuilder.Entity("TechnicalInsulation.Models.Elements.Vessel", b =>
                {
                    b.Navigation("Pipes");

                    b.Navigation("VesselBottoms");
                });
#pragma warning restore 612, 618
        }
    }
}
