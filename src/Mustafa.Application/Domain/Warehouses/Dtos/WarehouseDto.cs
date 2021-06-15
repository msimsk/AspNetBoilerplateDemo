using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Entities;

namespace Mustafa.Domain.Warehouses.Dtos
{
    public class WarehouseDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Descr { get; set; }
    }
}
