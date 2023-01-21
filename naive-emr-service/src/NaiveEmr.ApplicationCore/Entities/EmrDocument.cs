using NaiveEmr.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveEmr.ApplicationCore.Entities
{
    public class EmrDocument: IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string JsonContent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
