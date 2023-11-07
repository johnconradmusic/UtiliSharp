using System.IO;

namespace UtiliSharp.Core.Services;

public class FileService : IFileService
{
	public async Task<string> ReadTextAsync(string path)
	{
		return await File.ReadAllTextAsync(path);
	}

	public async Task WriteTextAsync(string path, string content)
	{
		await File.WriteAllTextAsync(path, content);
	}

	public async Task<byte[]> ReadBinaryAsync(string path)
	{
		return await File.ReadAllBytesAsync(path);
	}

	public async Task WriteBinaryAsync(string path, byte[] data)
	{
		await File.WriteAllBytesAsync(path, data);
	}

	public async Task<bool> ExistsAsync(string path)
	{
		return File.Exists(path);
	}

	public async Task<IEnumerable<string>> GetFilesAsync(string directoryPath)
	{
		// This method doesn't have to be async as Directory.GetFiles is not an I/O bound operation
		// But we keep it async to conform to the interface
		return Directory.GetFiles(directoryPath);
	}

	// Implement other file and directory methods as required...
}
