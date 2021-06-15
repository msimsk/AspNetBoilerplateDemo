using System.Threading.Tasks;
using Abp.Application.Services;
using Mustafa.Authorization.Accounts.Dto;

namespace Mustafa.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
