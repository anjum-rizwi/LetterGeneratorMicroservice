using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using LetterGenerator.Models;
using LetterGenerator.Services;

namespace LetterGenerator.Pages
{
    public class GenerateModel : PageModel
    {
        [BindProperty]
        public string LetterType { get; set; }

        [BindProperty]
        public string Status { get; set; }
        [TempData]
        public string? DownloadLink { get; set; }

        public IActionResult OnPost()
        {
            var request = new LetterRequest { ClientId = "123", LoanId = "LN-001", LetterType = LetterType };

            string? path = LetterType.ToLower() switch
            {
                "word" => new WordGenerator().Generate(request),
                "pdf" => new PdfGenerator().Generate(request),
                "prn" => new PrnGenerator().Generate(request),
                _ => null
            };

            if (path != null)
                DownloadLink = path.Replace("wwwroot", "");

            return RedirectToPage();
        }
    }
}
