using Abp.EntityFrameworkCore;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.EntityFrameworkCore.Repositories
{
    public class ProductRepository : MustafaRepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<MustafaDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
