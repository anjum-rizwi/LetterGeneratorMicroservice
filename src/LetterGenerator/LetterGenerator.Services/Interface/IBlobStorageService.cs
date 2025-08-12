namespace LetterGenerator.Services.Interface
{
    public interface IBlobStorageService
    {
        Task<string> UploadAsync(string clientId, byte[] content, string format);
    }
}