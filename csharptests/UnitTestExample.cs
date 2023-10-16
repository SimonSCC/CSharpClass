using LEGO.CSharpExamples.Infrastructure;
using LEGO.CSharpExamples.Materials;
using LEGO.CSharpExamples.Materials.Domain;
using LEGO.CSharpExamples.Materials.Models;
using LEGO.CSharpExamples.Materials.Services;
using NSubstitute;

namespace LEGO.CSharpExamples.Tests;

public class UnitTestExample
{
    //We need project reference to the assembly / project we want to test

    // Notice naming convention: MethodName_Scenario_ExpectedBehaviour
    [Fact]
    public void NameOfMethodBeingTested_Scenario_ExpectedBehaviour()
    {
        // Arrange  
        MaterialService materialService = new();
        Material material = Material.Create("test", "tetete", 0.7).HandleDomainError();

        // Act  
        double shippingCost = materialService.CalculateShippingCost(material, 20);

        // Assert  
        Assert.Equal(3, shippingCost);
    }
}