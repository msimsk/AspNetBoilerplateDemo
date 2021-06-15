using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Mustafa.Configuration.Dto;

namespace Mustafa.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MustafaAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
