using Abp.Dependency;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Manager
{
    public interface IEntityManager : ITransientDependency
    {
        //Task<Product> GetProductAsync(int productId);
        Task<Category> GetCategoryAsync(int categoryId);
        //Task<StockMove> GetStockMoveAsync(int stockMoveId);
    }
}
