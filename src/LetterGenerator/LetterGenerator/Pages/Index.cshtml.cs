using LetterGenerator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LetterGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILetterService _letterService;
        public IndexModel(ILetterService letterService) => _letterService = letterService;

        [BindProperty] public string RecipientName { get; set; }
        [BindProperty] public string Format { get; set; }
        public string? FileUrl { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            var url = await _letterService.GenerateLetterAsync(RecipientName, Format);
            FileUrl = url;
            return Page();
        }
    }
}