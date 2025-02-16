using Abp.Application.Services;
using OSW.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace OSW.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
