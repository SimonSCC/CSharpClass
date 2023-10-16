using LEGO.CSharpExamples.Materials;
using Microsoft.Extensions.DependencyInjection;

// - AddSingleton
// Singleton services are created only once,
// and the same instance is used for the entire lifetime of the application.

// - Add Scoped
// Scoped services are created once per request or scope.
// In the context of a console application, where there might not be an HTTP request,
// a scope could be thought of as the duration of the console application's execution.

// - Add Transient
// Transient services are created each time they are requested.
// If you register a service as transient, a new instance will be provided every time you ask for it.

ServiceProvider serviceProvider = new ServiceCollection()
    .AddTransient<IMaterialService, MaterialService>()
    .BuildServiceProvider();