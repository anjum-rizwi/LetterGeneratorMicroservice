namespace LetterGenerator.Services.Interface
{
    public interface IAzureFileService
    {
        Task<string[]> ListJobFilesAsync(string shareName, string directoryName);
        Task<string> ReadJobFileAsync(string shareName, string fileName);
        Task ReadJobFileAsync(string jobFilePath);
        Task ReadJobFileneAsync(string jobFilePath);
        Task SaveOutputAsync(object doc);
        Task UploadResultAsync(string shareName, string path, byte[] fileBytes);
    }
}