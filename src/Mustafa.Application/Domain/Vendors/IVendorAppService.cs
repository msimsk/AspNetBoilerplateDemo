using Abp.Application.Services;
using Mustafa.Domain.Vendors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Vendors
{
    public interface IVendorAppService : IAsyncCrudAppService<VendorDto, int, GetAllVendorInput, CreateVendorInput, UpdateVendorInput, GetVendorInput, DeleteVendotInput>
    {
        Task<List<VendorDto>> GetList();
    }
}
