using UtiliSharp.Core.MVVM;

public interface IDialogService
{
	Task ShowMessageAsync(string message, string title);
	Task<bool> ShowConfirmationAsync(string message, string title);
	Task<string> RequestInputAsync(string prompt, string title);
	Task<T> SelectFromListAsync<T>(string title, IEnumerable<T> options, Func<T, string> displayMember);
	Task<TResult> ShowCustomDialogAsync<TViewModel, TResult>(TViewModel viewModel) where TViewModel : ViewModelBase;
	// ... other dialog methods
}
