using LetterGenerator.Models;
using LetterGenerator.Services.Interface;
using System.Text;
using System.Text.Json;

namespace LetterGenerator.Services
{
    public class AtlasMailMergeService : IAtlasMailMergeService
    {
        public async Task<IEnumerable<object>> GenerateLettersAsync(object templatePath, object dataPath, object config)
        {
            // This simulates the result from a Mail Merge API
            await Task.Delay(500); // Simulate API delay

            var letters = new List<object>();

            // Simulate multiple letters
            for (int i = 1; i <= 2; i++)
            {
                var content = Encoding.UTF8.GetBytes($"Merged Letter {i} using template: {templatePath}");
                letters.Add(new
                {
                    FileName = $"Letter_{i}.pdf",
                    Content = content
                });
            }

            return letters;
        }

        public string MergeTemplateWithData(LetterRequest request)
        {
            // Simulate a merge by returning a string
            return $"Dear Customer,\n\nThis is your letter for Loan ID: {request.LoanId}, Client ID: {request.ClientId}.\n\nThank you.";
        }
    }
}
