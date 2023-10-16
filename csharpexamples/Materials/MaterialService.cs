using CSharpFunctionalExtensions;
using LEGO.CSharpExamples.Infrastructure;
using LEGO.CSharpExamples.Materials.Domain;

namespace LEGO.CSharpExamples.Materials;

public interface IMaterialService
{
    Material[] CreateStandardMaterials();
}

public class MaterialService : IMaterialService
{
    public Material[] CreateStandardMaterials()
    {
        Result<Material, Error> absCreateResult = Material.Create("ABS", "Acrylonitrile Butadiene Styrene");
        if (absCreateResult.IsFailure)
        {
            throw new Exception("Could not create ABS material");
        }

        Material ppMaterial = Material.Create("PP", "Polypropylene").HandleDomainError();

        return new[]
        {
            absCreateResult.Value,
            ppMaterial
        };
    }
}