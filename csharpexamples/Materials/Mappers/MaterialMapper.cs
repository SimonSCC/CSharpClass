using LEGO.CSharpExamples.Materials.Domain;
using LEGO.CSharpExamples.Materials.Models;

namespace LEGO.CSharpExamples.Materials.Mappers;

public static class MaterialMapper
{
    public static MaterialViewModel ToMaterialViewModel(this Material material)
    {
        return new MaterialViewModel(material.Name, material.Description);
    }
}