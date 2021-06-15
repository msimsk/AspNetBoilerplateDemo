using Abp.Application.Services;
using Mustafa.MultiTenancy.Dto;

namespace Mustafa.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

