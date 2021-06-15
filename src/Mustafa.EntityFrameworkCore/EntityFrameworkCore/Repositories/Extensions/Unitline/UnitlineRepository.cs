using Abp.EntityFrameworkCore;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.EntityFrameworkCore.Repositories
{
    public class UnitlineRepository : MustafaRepositoryBase<Unitline, int>, IUnitlineRepository
    {
        public UnitlineRepository(IDbContextProvider<MustafaDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
