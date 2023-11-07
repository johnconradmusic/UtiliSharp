using Microsoft.Extensions.DependencyInjection;
using UtiliSharp.Core.Services;
namespace UtiliSharp.Core.DependencyInjection;
public static class DependencyInjectionConfig
{
	public static ServiceProvider InitializeServiceProvider()
	{
		// Create a new service collection
		ServiceCollection serviceCollection = new ServiceCollection();

		// Configure the built-in logging services and add the console and debug providers
		serviceCollection.AddLogging();

		// Register your logging service
		serviceCollection.AddSingleton<ILoggingService, DefaultLoggingService>();

		// Configure your other services
		serviceCollection.AddTransient<IFileService, FileService>(); // Assuming FileService implements IFileService
		serviceCollection.AddSingleton<IDialogService, MockDialogService>(); // Assuming DialogService implements IDialogService
																			 // Add other services...

		// Build the service provider
		return serviceCollection.BuildServiceProvider();
	}
}
