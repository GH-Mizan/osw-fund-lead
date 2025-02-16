using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace OSW.Entities
{
    public class Desgnation : FullAuditedEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public bool Active { get; set; }
    }
}
