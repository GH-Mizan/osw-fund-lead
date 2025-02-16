using Abp.Application.Services;
using OSW.Sessions.Dto;
using System.Threading.Tasks;

namespace OSW.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
