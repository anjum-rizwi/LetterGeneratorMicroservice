using LetterGenerator.Models;
using LetterGenerator.Services;
using LetterGenerator.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LetterGenerator.Controllers
{
    public class GenerateController : Controller
    {
        private readonly BlobStorageService _blob;
        private readonly FileGeneratorService _fileGen;
        private readonly AtlasMailMergeService _mailMerge;
        private readonly EventGridPublisher _eventPublisher;
        private readonly JobHistoryService _history;

        public GenerateController(BlobStorageService blob, FileGeneratorService fileGen, AtlasMailMergeService mailMerge,
            EventGridPublisher eventPublisher, JobHistoryService history)
        {
            _blob = blob;
            _fileGen = fileGen;
            _mailMerge = mailMerge;
            _eventPublisher = eventPublisher;
            _history = history;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(JobRequest request)
        {
            var mergedContent = await _mailMerge.MergeAsync(request);
            var fileBytes = _fileGen.Generate(mergedContent, request.OutputFormat);
            var url = await _blob.UploadAsync(request.ClientId, fileBytes, request.OutputFormat);
            await _eventPublisher.PublishAsync(request.ClientId, url);
            await _history.SaveAsync(request, url);
            ViewBag.DownloadLink = url;
            return View();
        }

        public IActionResult Download(string clientId, string fileName)
        {
            var filePath = _blob.GetFilePath(clientId, fileName);
            return File(System.IO.File.ReadAllBytes(filePath), "application/octet-stream", fileName);
        }

       

        public async Task<IActionResult> UploadAsync(string clientId, string fileBytes)
        {
            var url = await _blob.UploadAsync(clientId, fileBytes, "pdf");

            return new JsonResult(new { url });
        }
    }
}
