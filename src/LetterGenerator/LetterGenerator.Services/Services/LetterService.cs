using LetterGenerator.Services.Interface;

namespace LetterGenerator.Services
{
    public class LetterService : ILetterService
    {
        public Task<string> GenerateLetterAsync(string recipient, string format)
        {
            // Dummy URL generation logic (to be replaced with actual logic)
            return Task.FromResult($"/downloads/sample.{format}");
        }
    }
}