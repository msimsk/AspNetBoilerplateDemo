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
using Mustafa.Domain.Unitlines.Dto;
using Mustafa.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Unitlines
{
    [AbpAuthorize(PermissionNames.Unitline)]
    public class UnitlineAppService : AsyncCrudAppService<Unitline, UnitlineDto, int, GetAllUnitlineInput, CreateUnitlineInput, UpdateUnitlineInput, GetUnitlineInput, DeleteUnitlineInput>, IUnitlineAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IUnitlineRepository _unitlineRepository;
        public UnitlineAppService(
            IUnitlineRepository unitlineRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<Unitline, int> repository) : base(repository)
        {
            _unitlineRepository = unitlineRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [AbpAuthorize(PermissionNames.Unitline_Create)]
        public override async Task<UnitlineDto> CreateAsync(CreateUnitlineInput input)
        {
            var unitline = new Unitline()
            {
                UnitType = input.UnitType,
                Descr = input.Descr
            };

            await _unitlineRepository.InsertAsync(unitline);
            await _unitOfWorkManager.Current.SaveChangesAsync();

            return MapToEntityDto(unitline);
        }
        [AbpAuthorize(PermissionNames.Unitline_Delete)]
        public override async Task DeleteAsync(DeleteUnitlineInput input)
        {
            var unitline = await _unitlineRepository.GetAsync(input.Id);
            if (unitline == null) throw new EntityNotFoundException(typeof(Unitline), input);

            unitline.IsDeleted = true;

            await _unitlineRepository.UpdateAsync(unitline);
            await _unitOfWorkManager.Current.SaveChangesAsync();
        }
        [AbpAuthorize(PermissionNames.Unitline_Get)]
        public override Task<UnitlineDto> GetAsync(GetUnitlineInput input)
        {
            return base.GetAsync(input);
        }
        [AbpAuthorize(PermissionNames.Unitline_GetList)]
        public override Task<PagedResultDto<UnitlineDto>> GetAllAsync(GetAllUnitlineInput input)
        {
            return base.GetAllAsync(input);
        }
        [AbpAuthorize(PermissionNames.Unitline_Update)]
        public override async Task<UnitlineDto> UpdateAsync(UpdateUnitlineInput input)
        {
            var unitline = await _unitlineRepository.GetAsync(input.Id);
            if (unitline == null) throw new EntityNotFoundException(typeof(Unitline), input);

            unitline.UnitType = input.UnitType.IsNullOrEmpty() ? unitline.UnitType : input.UnitType;
            unitline.Descr = input.Descr;

            await _unitlineRepository.UpdateAsync(unitline);
            await _unitOfWorkManager.Current.SaveChangesAsync();

            return MapToEntityDto(unitline);
        }

        protected override IQueryable<Unitline> CreateFilteredQuery(GetAllUnitlineInput input)
        {
            return Repository.GetAll()
                .WhereIf(!input.UnitType.IsNullOrWhiteSpace(), x => x.UnitType.Contains(input.UnitType) || x.Descr.Contains(input.UnitType))
                .Where(x => x.IsDeleted.Equals(input.IsDeleted));
        }

        public async Task<List<UnitlineDto>> GetList()
        {
            var unitlines = await _unitlineRepository.GetAllListAsync(x => x.IsDeleted.Equals(false));
            return ObjectMapper.Map<List<UnitlineDto>>(unitlines);
        }
    }
}
