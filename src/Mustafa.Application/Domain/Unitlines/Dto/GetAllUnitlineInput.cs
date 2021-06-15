using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Unitlines.Dto
{
    public class GetAllUnitlineInput : PagedResultRequestDto
    {
        public string UnitType { get; set; }
        public string Descr { get; set; }
        public bool IsDeleted { get; set; }
    }
}
