// --- Services/AtlasMailMergeService.cs ---
using LetterGenerator.Models;

namespace LetterGenerator.Services  
{
    public class AtlasMailMergeService
    {
        public string MergeTemplateWithData(LetterRequest request)
        {
            // Simulated call to ATLAS Mail Merge API
            return $"Merged letter for {request.LoanId}";
        }
    }
}