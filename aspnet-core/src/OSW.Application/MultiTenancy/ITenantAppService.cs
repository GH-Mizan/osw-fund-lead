using Abp.Application.Services;
using OSW.MultiTenancy.Dto;

namespace OSW.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

