using CSharpFunctionalExtensions;
using LEGO.CSharpExamples.Infrastructure;

namespace LEGO.CSharpExamples.Materials.Domain;

public class Material
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public static Result<Material, Error> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return MaterialError.MaterialNameIsRequired;
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return MaterialError.MaterialNameIsRequired;
        }

        return new Material(name, description);
    }

    private Material(string name, string description)
    {
        Name = name;
        Description = description;
    }

    private static class MaterialError
    {
        public static readonly Error MaterialNameIsRequired = new Error("name.is.required", "Name is required");

        public static readonly Error DescriptionIsRequired =
            new Error("description.is.required", "Description is required");
    }
}