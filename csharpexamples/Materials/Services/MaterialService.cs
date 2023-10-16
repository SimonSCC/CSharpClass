using CSharpFunctionalExtensions;
using LEGO.CSharpExamples.Infrastructure;
using LEGO.CSharpExamples.Materials.Domain;
using LEGO.CSharpExamples.Materials.Models;

namespace LEGO.CSharpExamples.Materials.Services;

public interface IMaterialService
{
    Material[] CreateStandardMaterials();
    Task<string?> GetMaterialInfoAsync(string materialName);
    double CalculateShippingCost(Material material, double distance);
}

public class MaterialService : IMaterialService
{
   

    public Material[] CreateStandardMaterials()
    {
        Result<Material, Error> absCreateResult = Material.Create("ABS", "Acrylonitrile Butadiene Styrene", 0.2);
        if (absCreateResult.IsFailure)
        {
            throw new Exception("Could not create ABS material");
        }

        Material ppMaterial = Material.Create("PP", "Polypropylene", 0.2).HandleDomainError();

        return new[]
        {
            absCreateResult.Value,
            ppMaterial
        };
    }

    public async Task<string?> GetMaterialInfoAsync(string materialName)
    {
        // Simulate async work  
        await Task.Delay(1000);

        if (materialName.ToLower() == "abs")
            return "Abs is a material consisting of any of a wide range of synthetic or semi-synthetic organic compounds that are malleable and can be molded into solid objects.";

        return null;
    }

    public double CalculateShippingCost(Material material, double distance)
    {
        // Assume a simple shipping cost calculation: $1 per kilogram per km.
        // Normally you could also have a lot of other factors, maybe even a domain model for ShippingProvider
        // With a method like: ShipMaterial(Material material)
        double weight = material.CalculateWeight();
        double cost = weight * distance;
        double rounded = Math.Ceiling(cost);
        return rounded;
    }
}