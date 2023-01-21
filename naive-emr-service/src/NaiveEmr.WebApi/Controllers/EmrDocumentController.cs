using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaiveEmr.ApplicationCore.Entities;
using NaiveEmr.ApplicationCore.Interfaces;
using NaiveEmr.WebApi.Dto;
using System.Text.Json;

namespace NaiveEmr.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmrDocumentController : ControllerBase
    {
        private readonly IEmrDocumentService _documentService;
        private readonly ILogger<EmrDocumentController> _logger;

        public EmrDocumentController(IEmrDocumentService documentService, ILogger<EmrDocumentController> logger)
        {
            _documentService = documentService;
            _logger = logger;
        }

        [HttpGet("{docId}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid docId)
        {
            var document = await _documentService.GetAsync(docId);
            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateDocumentDto emrDocumentDto)
        {
            EmrDocument emrDocument = new EmrDocument();
            var now = DateTime.Now;
            emrDocument.Id = Guid.NewGuid();
            emrDocument.Title = now.ToString();
            emrDocument.CreateTime = now;
            emrDocument.UpdateTime = now;
            emrDocument.JsonContent = emrDocumentDto.JsonContent;

            _logger.LogInformation(JsonSerializer.Serialize(emrDocument));
            var created = await _documentService.AddAsync(emrDocument);
            return Ok(created);
        }
    }
}
