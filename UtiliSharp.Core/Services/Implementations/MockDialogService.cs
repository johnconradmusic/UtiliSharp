using UtiliSharp.Core.MVVM;

namespace UtiliSharp.Core.Services;

public class MockDialogService : IDialogService
{
	public Task ShowMessageAsync(string message, string title)
	{
		Console.WriteLine($"{title}: {message}");
		return Task.CompletedTask;
	}

	public Task<bool> ShowConfirmationAsync(string message, string title)
	{
		Console.WriteLine($"{title}: {message} (y/n)");
		ConsoleKeyInfo key = Console.ReadKey();
		return Task.FromResult(key.KeyChar is 'y' or 'Y');
	}

	public Task<string> RequestInputAsync(string prompt, string title)
	{
		Console.WriteLine($"{title}: {prompt}");
		string input = Console.ReadLine();
		return Task.FromResult(input);
	}
	public async Task<T> SelectFromListAsync<T>(string title, IEnumerable<T> options, Func<T, string> displayMember)
	{
		Console.WriteLine(title);
		int index = 0;
		foreach (T? option in options)
		{
			Console.WriteLine($"{++index}: {displayMember(option)}");
		}
		Console.WriteLine("Enter the number of your choice:");

		while (true)
		{
			if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= options.Count())
			{
				return options.ElementAt(choice - 1);
			}
			Console.WriteLine("Invalid choice, please try again.");
		}
	}
	public Task<TResult> ShowCustomDialogAsync<TViewModel, TResult>(TViewModel viewModel)
			where TViewModel : ViewModelBase
	{
		// Simulate showing a custom dialog by writing to the console
		Console.WriteLine($"Showing custom dialog for view model of type {typeof(TViewModel).Name}");

		// Simulate getting a result from the dialog
		// In a real application, this might be the result of user input or interaction with the dialog
		TResult result = default;

		// Here we just return a default value for TResult
		// You would replace this with actual logic to set the result based on the dialog interaction
		return Task.FromResult(result);
	}
}
