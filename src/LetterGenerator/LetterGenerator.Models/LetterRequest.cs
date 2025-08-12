namespace LetterGenerator.Models
{
    public class LetterRequest
    {
        public string ClientId { get; set; }
        public string LoanId { get; set; }
        public string LetterType { get; set; }
    }
}
