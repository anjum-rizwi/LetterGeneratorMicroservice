using LetterGenerator.Models;
using System.IO;

namespace LetterGenerator.Services
{
    public class PdfGenerator
    {
        public string Generate(LetterRequest request)
        {
            var path = $"wwwroot/downloads/{request.ClientId}_letter.pdf";
            File.WriteAllText(path, $@"PDF Letter for Client {request.ClientId} and Loan {request.LoanId}");
            return path;
        }
    }
}
