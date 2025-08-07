namespace LetterGenerator.Services
{
    public interface ILetterService
    {
        Task<string> GenerateLetterAsync(string recipient, string format);
    }
}