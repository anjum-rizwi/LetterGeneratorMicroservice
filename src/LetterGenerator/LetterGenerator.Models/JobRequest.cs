namespace LetterGenerator.Models
{
    public class JobRequest
    {
        public string ClientId { get; set; }
        public string OutputFormat { get; set; }
        public string? TemplateName { get; set; }
    }
}
