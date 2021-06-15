using Abp.Application.Services;
using Mustafa.Domain.Unitlines.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Unitlines
{
    public interface IUnitlineAppService : IAsyncCrudAppService<UnitlineDto, int, GetAllUnitlineInput, CreateUnitlineInput, UpdateUnitlineInput, GetUnitlineInput, DeleteUnitlineInput>
    {
        Task<List<UnitlineDto>> GetList();
    }
}
