using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Entities
{
    public class StockMoveType : Entity<bool>
    {
        public StockMoveType()
        {
            GetStockMove = new HashSet<StockMove>();
        }
        public string TYPE { get; set; }
        public virtual ICollection<StockMove> GetStockMove { get; set; }

    }
}
