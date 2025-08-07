using LetterGenerator.Models;
using System.IO;

namespace LetterGenerator.Services
{
    public class PrnGenerator
    {
        public string Generate(LetterRequest request)
        {
            var path = $"wwwroot/downloads/{request.ClientId}_letter.prn";
            File.WriteAllText(path, $@"PRN Letter for Client {request.ClientId} and Loan {request.LoanId}");
            return path;
        }
    }
}
