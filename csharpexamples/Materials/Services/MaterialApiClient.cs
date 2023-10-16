using LEGO.CSharpExamples.Materials.Models;

namespace LEGO.CSharpExamples.Materials.Services;

public interface IMaterialApiClient
{
    Task<MaterialDto> GetMaterialFromExternalApiAsync();

}

public class MaterialApiClient : IMaterialApiClient
{
    public Task<MaterialDto> GetMaterialFromExternalApiAsync()
    {
        //Simulating call to api
        MaterialDto absPet = new()
        {
            Description = "absPet Descript ",
            Volume = 0.1,
            Name = "absPet"
        };

        Task.Delay(2000);
        return Task.FromResult(absPet);
    }
}