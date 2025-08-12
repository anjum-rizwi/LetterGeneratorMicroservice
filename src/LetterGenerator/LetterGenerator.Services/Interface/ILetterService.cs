namespace LetterGenerator.Services.Interface
{
    public interface ILetterService
    {
        Task<string> GenerateLetterAsync(string recipient, string format);
    }
}