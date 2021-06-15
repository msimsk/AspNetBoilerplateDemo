using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Products.Dtos;
using Mustafa.Domain.StockMoveTypes.Dto;
using Mustafa.Domain.Vendors.Dtos;
using Mustafa.Domain.Warehouses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.StockMoves.Dtos
{
    public class StockMoveFullOutPut : EntityDto<Int64>
    {
        public string Descr { get; set; }
        public float UnitPrice { get; set; }
        public float Quantity { get; set; }
        public virtual ProductPartOutPut Product { get; set; }
        public virtual WarehouseDto Warehouse { get; set; }
        public virtual VendorDto Vendor { get; set; }
        public virtual StockMoveTypeDto StockMoveType { get; set; }
    }
}
