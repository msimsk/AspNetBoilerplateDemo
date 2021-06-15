using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Entities
{
    public class Unitline : FullAuditedEntity<int>
    {
        public Unitline()
        {
            GetProducts = new HashSet<Product>();
        }
        public string UnitType{ get; set; }
        public string Descr { get; set; }
        public virtual ICollection<Product> GetProducts { get; set; }
    }
}
