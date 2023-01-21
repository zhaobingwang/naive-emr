using NaiveEmr.ApplicationCore.Entities;
using NaiveEmr.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveEmr.ApplicationCore.Services
{
    public class EmrDocumentService : IEmrDocumentService
    {
        private readonly IRepository<EmrDocument> _documentRepository;

        public EmrDocumentService(IRepository<EmrDocument> documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<EmrDocument> AddAsync(EmrDocument document)
        {
            return await _documentRepository.AddAsync(document);
        }

        public async Task<EmrDocument> GetAsync(Guid id)
        {
            return await _documentRepository.GetByIdAsync(id);
        }
    }
}
