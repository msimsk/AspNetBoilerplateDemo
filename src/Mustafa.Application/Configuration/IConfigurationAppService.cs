using System.Threading.Tasks;
using Mustafa.Configuration.Dto;

namespace Mustafa.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
