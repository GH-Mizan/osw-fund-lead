using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace OSW.Entities
{
    public class Member : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string PrimaryContact { get; set; }
        public string PotoPath { get; set; }
        public bool Active { get; set; }
    }
}
