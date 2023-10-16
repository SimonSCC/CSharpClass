using LEGO.CSharpExamples.Materials.Models;
using LEGO.CSharpExamples.Materials.Services;
using NSubstitute;

namespace LEGO.CSharpExamples.Tests;

public class IntegrationTestExample
{
    [Fact]
    public async Task GetAndCalculateShippingCostAsync_ReturnedMaterialHasNullName_ArgumentNullExceptionIsThrown()
    {
        // Arrange  
        IMaterialApiClient? materialApiClient = Substitute.For<IMaterialApiClient>();
        var testMaterial = new MaterialDto()
        {
            Volume = 3.0,
            Description = "Test"
        };
        materialApiClient.GetMaterialFromExternalApiAsync().Returns(testMaterial);

        App app = new App(new MaterialService(), materialApiClient);

        // Act  & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => app.GetAndCalculateShippingCostAsync());
    }

    [Fact]
    public async Task GetAndCalculateShippingCostAsync_ReturnedMaterialWithVolume_CalculatesExpected()
    {
        // Arrange  
        IMaterialApiClient? materialApiClient = Substitute.For<IMaterialApiClient>();
        var testMaterial = new MaterialDto()
        {
            Name = "TestTest",
            Volume = 3.0,
            Description = "Test"
        };
        materialApiClient.GetMaterialFromExternalApiAsync().Returns(testMaterial);

        App app = new App(new MaterialService(), materialApiClient);

        // Act
        double result = await app.GetAndCalculateShippingCostAsync();

        //Assert
        Assert.Equal(61, result);
    }
}