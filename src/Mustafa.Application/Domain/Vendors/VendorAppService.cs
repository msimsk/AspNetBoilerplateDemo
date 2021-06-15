using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Mustafa.Authorization;
using Mustafa.Domain.Vendors.Dtos;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mustafa.EntityFrameworkCore.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Domain.Entities;
using Abp.Linq.Extensions;

namespace Mustafa.Domain.Vendors
{
    [AbpAuthorize(PermissionNames.Vendor)]
    public class VendorAppService : AsyncCrudAppService<Vendor, VendorDto, int, GetAllVendorInput, CreateVendorInput, UpdateVendorInput, GetVendorInput, DeleteVendotInput>, IVendorAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IVendorRepository _vendorRepository;
        public VendorAppService(
            IVendorRepository vendorRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<Vendor, int> repository) : base(repository)
        {
            _vendorRepository = vendorRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [AbpAuthorize(PermissionNames.Vendor_Create)]
        public override async Task<VendorDto> CreateAsync(CreateVendorInput input)
        {
            var vendor = new Vendor()
            {
                Name = input.Name,
                Descr = input.Descr,
                TaxNo = input.TaxNo
            };

            await _vendorRepository.InsertAsync(vendor);
            await _unitOfWorkManager.Current.SaveChangesAsync();

            return MapToEntityDto(vendor);
        }
       
        [AbpAuthorize(PermissionNames.Vendor_Update)]
        public override async Task<VendorDto> UpdateAsync(UpdateVendorInput input)
        {
            var vendor = await _vendorRepository.GetAsync(input.Id);

            if (vendor == null) throw new EntityNotFoundException(typeof(Vendor), input);
            
            vendor.Name = input.Name.IsNullOrEmpty() ? vendor.Name : input.Name;
            vendor.Descr = input.Descr;
            vendor.TaxNo = input.TaxNo.IsNullOrEmpty() ? vendor.TaxNo : input.TaxNo;

            await _vendorRepository.UpdateAsync(vendor);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return MapToEntityDto(vendor);
        }

        [AbpAuthorize(PermissionNames.Vendor_Get)]
        public override Task<VendorDto> GetAsync(GetVendorInput input)
        {
            return base.GetAsync(input);
        }

        [AbpAuthorize(PermissionNames.Vendor_GetList)]
        public override Task<PagedResultDto<VendorDto>> GetAllAsync(GetAllVendorInput input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.Vendor_Delete)]
        public override async Task DeleteAsync(DeleteVendotInput input)
        {
            var vendor = await _vendorRepository.GetAsync(input.Id);

            if (vendor == null) throw new EntityNotFoundException(typeof(Vendor), input);

            vendor.IsDeleted = true;

            await _vendorRepository.UpdateAsync(vendor);
            await _unitOfWorkManager.Current.SaveChangesAsync();
        }

        protected override IQueryable<Vendor> CreateFilteredQuery(GetAllVendorInput input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name) || x.Descr.Contains(input.Name) || x.TaxNo.Contains(input.Name))
                .Where(x => x.IsDeleted.Equals(input.IsDeleted));
        }           

        public async Task<List<VendorDto>> GetList()
        {
            var vendors = await _vendorRepository.GetAllListAsync(x => x.IsDeleted.Equals(false));
            return ObjectMapper.Map<List<VendorDto>>(vendors);
        }
    }
}
