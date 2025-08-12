
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LetterGenerator.Services;
using LetterGenerator.Services.Interface;
using Microsoft.Extensions.Configuration;

namespace LetterGenerator.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "generated-letters";

        public BlobStorageService(IConfiguration configuration)
        {
            var connectionString = configuration["Azure:BlobConnection"];
            _blobServiceClient = new BlobServiceClient(connectionString);

            // Ensure container exists (optional for production)
            var container = _blobServiceClient.GetBlobContainerClient(_containerName);
            container.CreateIfNotExists(PublicAccessType.None);
        }

        public string GetFilePath(string clientId, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadAsync(string clientId, byte[] content, string format)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobName = $"{clientId}/{Guid.NewGuid()}.{format.ToLower()}";
            var blobClient = containerClient.GetBlobClient(blobName);

            using var stream = new MemoryStream(content);
            await blobClient.UploadAsync(stream, overwrite: true);

            return blobClient.Uri.ToString(); // Return direct link to blob
        }
    }
}
