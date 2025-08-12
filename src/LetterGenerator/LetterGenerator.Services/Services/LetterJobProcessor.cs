using LetterGenerator.Services.Interface;
using Microsoft.Extensions.Logging;

namespace LetterGenerator.Services
{
    public class LetterJobProcessor
    {
        private readonly IAtlasMailMergeService _atlasService;
        private readonly IAzureFileService _azureFileService;
        private readonly IClientConfigService _clientConfig;
        private readonly IJobHistoryService _historyService;
        private readonly IEventGridPublisher _eventGrid;
        private readonly ILogger<LetterJobProcessor> _logger;
        public async Task RunJobAsync(string jobFilePath)
        {
            // 1. Read client & job metadata
            await _azureFileService.ReadJobFileneAsync(jobFilePath); // Fix: Remove assignment, since method returns void

            // You may need to retrieve jobInfo from another source or method if required below.
            // var jobInfo = ...;

            // The rest of your code remains unchanged, but you must ensure jobInfo is properly initialized.
        }
    }
}
