using Abp.Domain.Repositories;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.EntityFrameworkCore.Repositories
{
    public interface IWarehouseRepository : IRepository<Warehouse, int>
    {
    }
}
