using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Entities
{
    public class Warehouse : FullAuditedEntity<int>
    {
        public Warehouse()
        {
            GetStockMove = new HashSet<StockMove>();
        }
        public string Name { get; set; }
        public string Descr { get; set; }
        [Ignore]
        public virtual ICollection<StockMove> GetStockMove { get; set; }
    }
}
