using LEGO.CSharpExamples.Infrastructure;
using LEGO.CSharpExamples.Materials.Domain;
using LEGO.CSharpExamples.Materials.Models;

namespace LEGO.CSharpExamples.Materials.Mappers;

public static class MaterialMapper
{
    public static MaterialViewModel ToMaterialViewModel(this Material material)
    {
        return new MaterialViewModel(material.Name, material.Description);
    }

    public static Material ToMaterial(this MaterialDto materialDto)
    {
        ArgumentNullException.ThrowIfNull(materialDto.Name);
        ArgumentNullException.ThrowIfNull(materialDto.Description);

        return Material.Create(materialDto.Name, materialDto.Description, materialDto.Volume).HandleDomainError();
    }
}