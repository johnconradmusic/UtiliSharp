namespace UtiliSharp.Core.Services;

public interface ILoggingService
{
	void LogInformation(string message);
	void LogWarning(string message);
	void LogError(string message);
	void LogError(Exception exception, string message);
	// Additional logging level methods as needed
}
