using Abp.Application.Services;
using Mustafa.Domain.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryFullOutPut, int, GetAllCategoryInput, CreateCategoryInput, UpdateCategoryInput, GetCategoryInput, DeleteCategoryInput>
    {
        Task<List<CategoryFullOutPut>> GetList();
    }
}
