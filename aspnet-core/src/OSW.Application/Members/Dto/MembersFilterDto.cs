using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSW.Common.Dto;

namespace OSW.Members.Dto
{
    public class MembersFilterDto: FilterBaseDto
    {
        public string SearchText { get; set; }
    }
}
