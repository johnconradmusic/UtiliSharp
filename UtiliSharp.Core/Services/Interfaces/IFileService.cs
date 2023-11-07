public interface IFileService
{
	Task<string> ReadTextAsync(string path);
	Task WriteTextAsync(string path, string content);
	Task<byte[]> ReadBinaryAsync(string path);
	Task WriteBinaryAsync(string path, byte[] data);
	Task<bool> ExistsAsync(string path);
	Task<IEnumerable<string>> GetFilesAsync(string directoryPath);
	// ... other file and directory methods
}
