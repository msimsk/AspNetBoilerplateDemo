using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.StockMoveTypes.Dto
{
    public class StockMoveTypeDto : EntityDto<bool>
    {
        public string TYPE { get; set; }
    }
}
