using LetterGenerator.Models;
using System.IO;

namespace LetterGenerator.Services
{
    public class WordGenerator
    {
        public string Generate(LetterRequest request)
        {
            var path = $"wwwroot/downloads/{request.ClientId}_letter.docx";
            File.WriteAllText(path, $@"Word Letter for Client {request.ClientId} and Loan {request.LoanId}");
            return path;
        }
    }
}
