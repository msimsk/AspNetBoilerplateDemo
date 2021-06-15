using Abp.Application.Services;
using Mustafa.Domain.Warehouses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Warehouses
{
    public interface IWarehouseAppService : IAsyncCrudAppService<WarehouseDto, int, GetAllWarehouseInput, CreateWarehouseInput, UpdateWarehouseInput, GetWarehouseInput, DeleteWarehouseInput>
    {
        Task<List<WarehouseDto>> GetList();
    }
}
