using Abp.Application.Services;
using Mustafa.Domain.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Products
{
    public interface IProductAppService : IAsyncCrudAppService<ProductFullOutPut, int, GetAllProductInput, CreateProductInput, UpdateProductInput, GetProductInput, DeleteProductInput>
    {
        Task<List<ProductFullOutPut>> GetList();
    }
}
