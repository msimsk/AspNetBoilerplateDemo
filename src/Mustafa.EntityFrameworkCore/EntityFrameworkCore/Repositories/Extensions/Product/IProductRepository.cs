using Abp.Domain.Repositories;
using Mustafa.Domain.Entities;
using System;

namespace Mustafa.EntityFrameworkCore.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}
