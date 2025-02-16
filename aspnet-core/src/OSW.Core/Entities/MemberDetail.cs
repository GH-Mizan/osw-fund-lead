using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace OSW.Entities
{
    public class MemberDetail: FullAuditedEntity
    {
        public int MemberId { get; set; }
        public string Address { get; set; }
        public string SecondaryContact { get; set; }
        public string BloodGroup { get; set; }
    }
}
