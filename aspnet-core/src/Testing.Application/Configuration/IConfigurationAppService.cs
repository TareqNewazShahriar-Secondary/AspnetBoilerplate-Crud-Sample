using System.Threading.Tasks;
using Testing.Configuration.Dto;

namespace Testing.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
