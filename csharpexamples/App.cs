using LEGO.CSharpExamples.Infrastructure;
using LEGO.CSharpExamples.Materials;
using LEGO.CSharpExamples.Materials.Domain;
using LEGO.CSharpExamples.Materials.Mappers;
using LEGO.CSharpExamples.Materials.Models;
using LEGO.CSharpExamples.Materials.Services;

namespace LEGO.CSharpExamples;

public class App
{
    private readonly IMaterialService _materialService;
    private readonly IMaterialApiClient _materialApiClient;

    public App(IMaterialService materialService, IMaterialApiClient materialApiClient)
    {
        _materialService = materialService;
        _materialApiClient = materialApiClient;
    }

    public void Run()
    {
        Material[] materials = _materialService.CreateStandardMaterials();
        foreach (Material material in materials)
        {
            Thread.Sleep(100);
            Console.WriteLine(material.Name);
        }
    }

    public async Task RunAsync()
    {
        Material[] materials = _materialService.CreateStandardMaterials();
        foreach (Material material in materials)
        {
            await Task.Delay(100);
            Console.WriteLine(material);
        }
    }

    public async Task<double> GetAndCalculateShippingCostAsync()
    {
        MaterialDto materialDto = await _materialApiClient.GetMaterialFromExternalApiAsync();
        return _materialService.CalculateShippingCost(materialDto.ToMaterial(), 100);
    }
}