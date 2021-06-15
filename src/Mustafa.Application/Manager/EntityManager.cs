using Abp.Domain.Entities;
using Abp.Domain.Uow;
using Abp.Localization;
using Abp.ObjectMapping;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using Mustafa.Domain.Entities;
using Mustafa.EntityFrameworkCore.Repositories;
using Mustafa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Manager
{
    public class EntityManager : AbpAppServiceBase, IEntityManager
    {
        private readonly ICategoryRepository _categoryRepository;
        //private readonly IStockMoveRepository _stockMoveRepository;
        //private readonly IProductRepository _productRepository;

        public EntityManager(
            IAbpSession abpSession,
            ILocalizationManager localizationManager,
            ILogger logger,
            IUnitOfWorkManager unitOfWorkManager,
            IObjectMapper objectMapper,
            ICategoryRepository categoryRepository
            //IStockMoveRepository stockMoveRepository)
            ): base(abpSession, localizationManager, logger, unitOfWorkManager, objectMapper)
        {
            _categoryRepository = categoryRepository;
            //_stockMoveRepository = stockMoveRepository;
            //_productRepository = productRepository;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(
                x => x.Id.Equals(categoryId)
                //*** kullanıcı adı
                //&& x.CreatorUserId.Equals(AbpSession.UserId)
                );
            if (category == null)
                throw new EntityNotFoundException(typeof(Category), categoryId);

            return category;
        }

        //public async Task<Product> GetProductAsync(int productId)
        //{
        //    var product = await _productRepository.FirstOrDefaultAsync(
        //        x => x.Id.Equals(productId));
        //    if (product == null)
        //        throw new EntityNotFoundException(typeof(Product), productId);

        //    return product;
        //}

        //public async Task<StockMove> GetStockMoveAsync(int stockMoveId)
        //{
        //    var stockMove = await _stockMoveRepository.FirstOrDefaultAsync(
        //        x => x.Id.Equals(stockMoveId));
        //    if (stockMove == null)
        //        throw new EntityNotFoundException(typeof(StockMove), stockMoveId);

        //    return stockMove;
        //}
    }
}
