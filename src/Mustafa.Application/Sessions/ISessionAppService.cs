using System.Threading.Tasks;
using Abp.Application.Services;
using Mustafa.Sessions.Dto;

namespace Mustafa.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
