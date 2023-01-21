using NaiveEmr.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveEmr.ApplicationCore.Interfaces
{
    public interface IEmrDocumentService
    {
        Task<EmrDocument> GetAsync(Guid id);
        Task<EmrDocument> AddAsync(EmrDocument document);
    }
}
