using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Mustafa.Authorization;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Warehouses.Dtos;
using Mustafa.EntityFrameworkCore.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mustafa.Domain.Warehouses
{
    [AbpAuthorize(PermissionNames.Warehouse)]
    public class WarehouseAppService : AsyncCrudAppService<Warehouse, WarehouseDto, int, GetAllWarehouseInput, CreateWarehouseInput, UpdateWarehouseInput, GetWarehouseInput, DeleteWarehouseInput>, IWarehouseAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseAppService(IRepository<Warehouse, int> repository
            , IUnitOfWorkManager unitOfWorkManager
            , IWarehouseRepository warehouseRepository
            ) : base(repository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _warehouseRepository = warehouseRepository;
        }

        [AbpAuthorize(PermissionNames.Warehouse_Create)]
        public override async Task<WarehouseDto> CreateAsync(CreateWarehouseInput input)
        {
            var warehouse = new Warehouse()
            {
                Name = input.Name,
                Descr = input.Descr,
            };

            await _warehouseRepository.InsertAsync(warehouse);
            await _unitOfWorkManager.Current.SaveChangesAsync();

            return MapToEntityDto(warehouse);
        }
        [AbpAuthorize(PermissionNames.Warehouse_Update)]
        public override async Task<WarehouseDto> UpdateAsync(UpdateWarehouseInput input)
        {
            var warehouse = await _warehouseRepository.GetAsync(input.Id);

            if (warehouse == null)
                throw new EntityNotFoundException(typeof(Warehouse), input.Id);

            warehouse.Name = input.Name.IsNullOrEmpty() ? warehouse.Name : input.Name;
            warehouse.Descr = input.Descr;

            await _warehouseRepository.UpdateAsync(warehouse);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return MapToEntityDto(warehouse);
        }
        [AbpAuthorize(PermissionNames.Warehouse_Delete)]
        public override async Task DeleteAsync(DeleteWarehouseInput input)
        {
            var warehouse = await _warehouseRepository.GetAsync(input.Id);
            if (warehouse == null) throw new EntityNotFoundException(typeof(Warehouse), input.Id);

            warehouse.IsDeleted = true;


            await _warehouseRepository.UpdateAsync(warehouse);
            await _unitOfWorkManager.Current.SaveChangesAsync();
        }
        [AbpAuthorize(PermissionNames.Warehouse_GetList)]
        public override Task<PagedResultDto<WarehouseDto>> GetAllAsync(GetAllWarehouseInput input)
        {
            return base.GetAllAsync(input);
        }
        [AbpAuthorize(PermissionNames.Warehouse_Get)]
        public override Task<WarehouseDto> GetAsync(GetWarehouseInput input)
        {
            return base.GetAsync(input);
        }
        protected override IQueryable<Warehouse> CreateFilteredQuery(GetAllWarehouseInput input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name) || x.Descr.Contains(input.Name))
                .Where(x => x.IsDeleted.Equals(input.IsDeleted));
        }

        public async Task<List<WarehouseDto>> GetList()
        {
            var warehouses = await _warehouseRepository.GetAllListAsync(x => x.IsDeleted.Equals(false));
            return ObjectMapper.Map<List<WarehouseDto>>(warehouses);
        }
    }
}
