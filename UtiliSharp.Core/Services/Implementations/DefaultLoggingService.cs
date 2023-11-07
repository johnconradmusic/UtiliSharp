using Microsoft.Extensions.Logging;
namespace UtiliSharp.Core.Services;

public class DefaultLoggingService : ILoggingService
{
	private readonly ILogger _logger;

	public DefaultLoggingService(ILogger logger)
	{
		_logger = logger;
	}

	public void LogInformation(string message)
	{
		_logger.LogInformation(message);
	}

	public void LogWarning(string message)
	{
		_logger.LogWarning(message);
	}

	public void LogError(string message)
	{
		_logger.LogError(message);
	}

	public void LogError(Exception exception, string message)
	{
		_logger.LogError(exception, message);
	}
}