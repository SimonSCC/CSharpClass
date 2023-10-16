namespace LEGO.CSharpExamples.Materials.Models;

public record MaterialViewModel
{
    /// <summary>
    /// Name of material
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Description of materila
    /// </summary>
    public string Description { get; }

    public MaterialViewModel(string name, string description)
    {
        Name = name;
        Description = description;
    }

    //You can have multiple constructors (ctor). Preferably we'd have one. Per default a class has an empty constructor, unless you specify one.
    public MaterialViewModel(string name)
    {
        Name = "test";
        Description = "Desc";
    }
}