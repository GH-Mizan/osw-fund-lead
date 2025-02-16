using Abp.Authorization;
using Abp.Runtime.Session;
using OSW.Configuration.Dto;
using System.Threading.Tasks;

namespace OSW.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : OSWAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
