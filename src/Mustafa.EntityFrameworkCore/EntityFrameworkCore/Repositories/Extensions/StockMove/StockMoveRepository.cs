using Abp.EntityFrameworkCore;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.EntityFrameworkCore.Repositories
{
    public class StockMoveRepository : MustafaRepositoryBase<StockMove, Int64>, IStockMoveRepository
    {
        public StockMoveRepository(IDbContextProvider<MustafaDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
