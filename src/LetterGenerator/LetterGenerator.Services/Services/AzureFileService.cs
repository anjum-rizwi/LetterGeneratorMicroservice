using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using LetterGenerator.Services.Interface;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace LetterGeneratorJob.Services
{
    public class AzureFileService : IAzureFileService
    {
        private readonly ShareServiceClient _shareServiceClient;

        public AzureFileService(IConfiguration configuration)
        {
            var connectionString = configuration["Azure:FileShareConnection"];
            _shareServiceClient = new ShareServiceClient(connectionString);
        }

        public async Task<string[]> ListJobFilesAsync(string shareName, string directoryName)
        {
            var share = _shareServiceClient.GetShareClient(shareName);
            var directory = share.GetDirectoryClient(directoryName);
            var fileNames = new List<string>();

            await foreach (var item in directory.GetFilesAndDirectoriesAsync())
            {
                if (!item.IsDirectory)
                {
                    fileNames.Add(item.Name);
                }
            }

            return fileNames.ToArray();
        }

        public async Task<string> ReadJobFileAsync(string shareName, string fileName)
        {
            var share = _shareServiceClient.GetShareClient(shareName);
            var rootDirectory = share.GetRootDirectoryClient();
            var fileClient = rootDirectory.GetFileClient(fileName);

            var downloadInfo = await fileClient.DownloadAsync();
            using var reader = new StreamReader(downloadInfo.Value.Content, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }

        public async Task ReadJobFileAsync(string jobFilePath)
        {
            // Simulate reading a file path like "\\share\folder\file.txt"
            await Task.CompletedTask;
            Console.WriteLine($"[Stub] ReadJobFileAsync: {jobFilePath}");
        }

        public async Task ReadJobFileneAsync(string jobFilePath)
        {
            // Simulate another job file processor (possibly renamed or typo)
            await Task.CompletedTask;
            Console.WriteLine($"[Stub] ReadJobFileneAsync: {jobFilePath}");
        }

        public async Task SaveOutputAsync(object doc)
        {
            // Serialize or save the generated document (placeholder/stub)
            await Task.CompletedTask;
            Console.WriteLine($"[Stub] SaveOutputAsync: {doc?.ToString()}");
        }

        public async Task UploadResultAsync(string shareName, string path, byte[] fileBytes)
        {
            var share = _shareServiceClient.GetShareClient(shareName);
            var directory = share.GetRootDirectoryClient();
            var fileClient = directory.GetFileClient(path);

            await fileClient.CreateAsync(fileBytes.Length);

            using var stream = new MemoryStream(fileBytes);
            await fileClient.UploadRangeAsync(
                new HttpRange(0, fileBytes.Length),
                stream
            );
        }
    }
}
