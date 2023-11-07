using UtiliSharp.Core.MVVM;

public interface INavigationService
{
	void NavigateTo(string pageKey, object parameter = null);
	void NavigateTo<TViewModel>(object parameter = null) where TViewModel : ViewModelBase;
	bool CanNavigate(string pageKey);
	void GoBack();
	// ... other navigation methods
}
