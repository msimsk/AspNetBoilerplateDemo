using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Entities
{
    public class Product : FullAuditedEntity<int>
    {
        public Product()
        {
            GetStockMoves = new HashSet<StockMove>();
        }
        public string Name { get; set; }

        public string ImgPath { get; set; }

        public string Descr { get; set; }

        public float LastPrice { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? UnitlineId { get; set; }
        public virtual Unitline Unitline { get; set; }
        public virtual ICollection<StockMove> GetStockMoves { get; set; }
    }
}
