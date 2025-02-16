using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSW.Members.Dto
{
    public class MemberEntryDto
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string PrimaryContact { get; set; }
        public string PotoPath { get; set; }
        public string Address { get; set; }
        public string SecondaryContact { get; set; }
        public string BloodGroup { get; set; }
    }
}
