namespace LEGO.CSharpExamples.Materials.Domain;

public class Material
{
    public string Name { get;  }
    public int Id { get;  }

    public static Result<Material, Error> Create()
    {
        
    }

    private Material()
    {
        
    }
}