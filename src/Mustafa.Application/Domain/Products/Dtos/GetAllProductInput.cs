using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Categories.Dtos;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Unitlines.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Products.Dtos
{

    public class GetAllProductInput : PagedResultRequestDto
    {
        public string Name { get; set; }
        ////public string IMG_PATH { get; set; }
        //public string DESCR { get; set; }
        //public float LASTPRICE { get; set; }
        public bool IsDeleted { get; set; }
        //public CategoryPartOutPut Category { get; set; }
        //public UnitlinePartOutPut Unitline { get; set; }
    }
}
