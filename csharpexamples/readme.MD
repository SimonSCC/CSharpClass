https://enterprisecraftsmanship.com/posts/advanced-error-handling-techniques/


PLAN
* Single responsibility principle from SOLID
* Dependency injection
* Mappers
* Interfaces
* Warnings
* Unit testing
* Mocking
* Object Oriented Programming
* Nuget Packages
* Access modifiers
* Namespaces, root namespace
* CSharpFunctionalExtensions - Vladamir Khorikov (Pluralsight), classes can have enumeration of what errors can be produced
* Overwriting ToString() method, and other default methods





### Integration tests:
(Ill make implementation of this if required)
For creating integration tests in a Console application, you can use a similar approach to the WebApplicationFactory used in ASP.NET Core, but with some differences because a Console app doesn't have the same web-oriented setup or lifecycle. You might create a custom "ConsoleApplicationFactory" that initializes your application and provides a way to interact with it.

Here's a very basic example of what this might look like:
public class ConsoleApplicationFactory : IDisposable  
{  
private ServiceProvider _serviceProvider;

    public ConsoleApplicationFactory()  
    {  
        var serviceCollection = new ServiceCollection();  
  
        // Register your services here, e.g.  
        serviceCollection.AddTransient<IMaterialService, MaterialService>();  
  
        _serviceProvider = serviceCollection.BuildServiceProvider();  
    }  
  
    public TService GetService<TService>()  
    {  
        return _serviceProvider.GetRequiredService<TService>();  
    }  
  
    public void Dispose()  
    {  
        // Dispose the service provider to clean up your services  
        _serviceProvider?.Dispose();  
    }  
}

And here's how you might use it in a test:
public class IntegrationTests : IDisposable  
{  
private readonly ConsoleApplicationFactory _factory;

    public IntegrationTests()  
    {  
        _factory = new ConsoleApplicationFactory();  
    }  
  
    [Fact]  
    public void TestMethod()  
    {  
        // Arrange  
        var materialService = _factory.GetService<IMaterialService>();  
          
        // Your test code here...  
    }  
  
    public void Dispose()  
    {  
        _factory?.Dispose();  
    }  
}

In this example, ConsoleApplicationFactory sets up a DI container with your services, and provides a way to get instances of those services. You can then use these services to interact with your application in your tests.

Please note that integration tests should ideally involve multiple components of the application, including the database, in a test that closely simulates the actual running conditions. If you have a database or other external dependencies, you should include them in your tests appropriately.

Also note that this is a very basic example and doesn't include some things you might need in a real-world application, like configuration management, logging, or handling the application's lifecycle. The implementation of your ConsoleApplicationFactory will depend on your specific application and needs.

