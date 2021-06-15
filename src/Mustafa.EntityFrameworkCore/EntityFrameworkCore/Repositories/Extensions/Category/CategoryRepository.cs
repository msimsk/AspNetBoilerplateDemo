using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Mustafa.Domain.Entities;

namespace Mustafa.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : MustafaRepositoryBase<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<MustafaDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
