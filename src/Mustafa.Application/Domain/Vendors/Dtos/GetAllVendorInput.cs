using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Vendors.Dtos
{
    public class GetAllVendorInput : PagedResultRequestDto
    {
        public string Name { get; set; }
        public string Descr { get; set; }
        public string TaxNo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
