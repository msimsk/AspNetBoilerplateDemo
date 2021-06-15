using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.StockMoves.Dtos
{
    public class StockMovePartOutPut : EntityDto<Int64>
    {
        public string Descr { get; set; }
        public float UnitPrice { get; set; }
        public float Quantity { get; set; }
    }
}
