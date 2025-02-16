using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Castle.Components.DictionaryAdapter.Xml;
using OSW.Authorization.Roles;
using OSW.Entities;
using OSW.Members.Dto;

namespace OSW.Members
{
    public class MemberAppService(
        IRepository<Member> memberRepository,
        IRepository<MemberDetail> memberDetailRepository
        ) : OSWAppServiceBase, IMemberAppService
    {
        private readonly IRepository<Member> _memberRepository = memberRepository;
        private readonly IRepository<MemberDetail> _memberDetailRepository = memberDetailRepository;

        public async Task<PagedResultDto<MemberOutputDto>> GetPaginatedMembersAsync(MembersFilterDto filter)
        {
            var query = (from m in await _memberRepository.GetAllAsync()
                         join md in await _memberDetailRepository.GetAllAsync() on m.Id equals md.MemberId
                         select new MemberOutputDto()
                         {
                             Name = m.Name,
                             Email = m.Email,
                             Address = md.Address,
                             PrimaryContact = m.PrimaryContact
                         }).AsQueryable();

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = query.Where(x =>
                                    x.Name.Contains(filter.SearchText) ||
                                    x.Address.Contains(filter.SearchText) ||
                                    x.Email.Contains(filter.SearchText) ||
                                    x.PrimaryContact.Contains(filter.SearchText) ||
                                    x.SecondaryContact.Contains(filter.SearchText)
                        ).AsQueryable();
            }

            return new PagedResultDto<MemberOutputDto>()
            {
                Items = query.Skip(filter.Skip).Take(filter.Take).ToList(),
                TotalCount = query.Count()
            };
        }

        public async Task CreateAsync(MemberEntryDto input)
        {
            var member = ObjectMapper.Map<Member>(input);
            await _memberRepository.InsertAsync(member);

            var memberDetail = ObjectMapper.Map<MemberDetail>(input);
            memberDetail.MemberId = member.Id;
            await _memberDetailRepository.InsertAsync(memberDetail);
        }
    }


}
