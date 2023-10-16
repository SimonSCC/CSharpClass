using CSharpFunctionalExtensions;
using LEGO.CSharpExamples.Infrastructure;

namespace LEGO.CSharpExamples.Materials.Domain;

public class Material
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Density { get; set; } = 0.2;
    public double Volume { get; set; } = 0.9;

    // This method represents domain logic  
    public double CalculateWeight()
    {
        return Density * Volume;
    }


    public static Result<Material, Error> Create(string name, string description, double volume)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return MaterialError.MaterialNameIsRequired;
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return MaterialError.MaterialNameIsRequired;
        }

        return new Material(name, description, volume);
    }

    private Material(string name, string description, double volume)
    {
        Name = name;
        Description = description;
        Volume = volume;
    }

    private static class MaterialError
    {
        public static readonly Error MaterialNameIsRequired = new Error("name.is.required", "Name is required");

        public static readonly Error DescriptionIsRequired =
            new Error("description.is.required", "Description is required");
    }
}