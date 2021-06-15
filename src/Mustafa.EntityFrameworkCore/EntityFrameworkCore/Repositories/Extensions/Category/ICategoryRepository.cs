using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Mustafa.Domain.Entities;

namespace Mustafa.EntityFrameworkCore.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    { 
    }
}
