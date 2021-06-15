using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Entities
{
    public class StockMove : FullAuditedEntity<Int64>
    {
        public StockMove()
        {
        }
        public string Descr { get; set; }
        public float UnitPrice { get; set; }
        public float Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public int? WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public bool StockMoveTypeId { get; set; }
        public virtual StockMoveType StockMoveType { get; set; }
    }
}
