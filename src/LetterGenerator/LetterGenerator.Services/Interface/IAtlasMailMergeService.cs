// --- Services/AtlasMailMergeService.cs ---
using LetterGenerator.Models;

namespace LetterGenerator.Services.Interface
{
    public interface IAtlasMailMergeService
    {
        Task<IEnumerable<object>> GenerateLettersAsync(object templatePath, object dataPath, object config);
        string MergeTemplateWithData(LetterRequest request);
    }
}