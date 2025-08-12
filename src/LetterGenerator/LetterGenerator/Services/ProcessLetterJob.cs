using LetterGenerator.Models;
using LetterGenerator.Services.interfaces;
using LetterGenerator.Services.MailMerge;
namespace LetterGenerator.Services
{
    public class ProcessLetterJob
    {
        private readonly IBlobStorageService _blobService;
        private readonly IAtlasMailMergeService _mailMerge;

        public ProcessLetterJob(IBlobStorageService blobService, IAtlasMailMergeService mailMerge)
        {
            _blobService = blobService;
            _mailMerge = mailMerge;
        }

        [FunctionName("ProcessLetterJob")]
        public async Task Run(
            [ServiceBusTrigger("letter-jobs", Connection = "ServiceBusConnection")] string queueMessage,
            ILogger log)
        {
            var request = JsonSerializer.Deserialize<LetterRequest>(queueMessage);

            // Call Mail Merge Microservice
            var content = await _mailMerge.GenerateMergedContentAsync(request);

            // Generate file (based on request.LetterType)
            byte[] fileBytes = FileGeneratorFactory.Create(request.LetterType).Generate(content);

            // Save to Azure Blob
            string fileName = $"{request.ClientId}_{request.LoanId}.{request.LetterType}";
            var blobUrl = await _blobService.UploadAsync(fileBytes, fileName);

            log.LogInformation($"Letter generated and uploaded to: {blobUrl}");

            // Optionally update job history table or send email
        }
    }

}
