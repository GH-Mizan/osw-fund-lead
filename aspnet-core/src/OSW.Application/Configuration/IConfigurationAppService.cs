using OSW.Configuration.Dto;
using System.Threading.Tasks;

namespace OSW.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
