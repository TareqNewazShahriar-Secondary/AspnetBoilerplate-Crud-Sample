using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Testing.Configuration.Dto;

namespace Testing.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TestingAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
