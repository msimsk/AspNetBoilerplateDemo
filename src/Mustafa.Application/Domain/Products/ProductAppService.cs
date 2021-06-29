using Abp.Authorization;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Mustafa.Authorization;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Products.Dtos;
using Mustafa.EntityFrameworkCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Mustafa.Domain.Products;
using System.Collections.Generic;
using Mustafa.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using Mustafa.ElasticSearchs;

namespace MustafaDenemeCore.Domain
{
    [AbpAuthorize(PermissionNames.Product)]
    public class ProductAppService : AsyncCrudAppService<Product, ProductFullOutPut, int, GetAllProductInput, CreateProductInput, UpdateProductInput, GetProductInput, DeleteProductInput>, IProductAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IProductRepository _productRepository;
        private readonly IElasticSearchManager _elasticSearchManager;

        [System.Obsolete]
        public ProductAppService(
            IUnitOfWorkManager unitOfWorkManager,
            IProductRepository productRepository,
            IElasticSearchManager elasticSearchManager,
            IRepository<Product, int> repository) : base(repository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _productRepository = productRepository;
            _elasticSearchManager = elasticSearchManager;
        }

        [AbpAuthorize(PermissionNames.Product_Create)]
        public override async Task<ProductFullOutPut> CreateAsync([FromForm] CreateProductInput input)
        {
            var product = new Product()
            {
                Name = input.Name,
                ImgPath = FileHelper.UploadFileAndGetPath(input.myImg),
                Descr = input.Descr,
                LastPrice = input.LastPrice == null ? 0 : (float)input.LastPrice,
                CategoryId = input.Category?.Id,
                UnitlineId = input.Unitline?.Id
            };

            await _productRepository.InsertAsync(product);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            await _elasticSearchManager.AddOrUpdateIndexAsync<Product, int>(product);

            return MapToEntityDto(product);
        }

        [AbpAuthorize(PermissionNames.Product_Delete)]
        public override async Task DeleteAsync(DeleteProductInput input)
        {
            //var product = await _productRepository.GetAsync(input.Id);

            //if (product == null) throw new EntityNotFoundException(typeof(Product), input);

            //product.IsDeleted = true;

            //await _productRepository.UpdateAsync(product);
            //await _unitOfWorkManager.Current.SaveChangesAsync();
            await base.DeleteAsync(input);
            var product = await _productRepository.GetAsync(input.Id);
            await _elasticSearchManager.AddOrUpdateIndexAsync<Product, int>(product);

        }

        [AbpAuthorize(PermissionNames.Product_Get)]
        public override async Task<ProductFullOutPut> GetAsync(GetProductInput input)
        {
            //var product = _productRepository.GetAllIncluding(x => x.Category, x => x.Unitline).Where(x => x.Id.Equals(input.Id)).First();
            //if (product == null) throw new EntityNotFoundException(typeof(Product), input);
            //return MapToEntityDto(product);
            return await base.GetAsync(input);
        }
        [AbpAuthorize(PermissionNames.Product_GetList)]
        public override async Task<PagedResultDto<ProductFullOutPut>> GetAllAsync(GetAllProductInput input)
        {
            //var products = await _productRepository.GetAllListAsync();
            //var output = ObjectMapper.Map<PagedResultDto<ProductFullOutPut>>(products);

            //return output;


            return await base.GetAllAsync(input);
        }
        [AbpAuthorize(PermissionNames.Product_Update)]
        public override async Task<ProductFullOutPut> UpdateAsync([FromForm] UpdateProductInput input)
        {
            var product = await _productRepository.GetAsync(input.Id);

            if (product == null) throw new EntityNotFoundException(typeof(Product), input);

            if (input.myImg != null)
            {
                product.ImgPath = FileHelper.UploadFileAndGetPath(input.myImg);
            }

            product.Name = input.Name.IsNullOrEmpty() ? product.Name : input.Name;
            product.Descr = input.Descr.IsNullOrEmpty() ? product.Descr : input.Descr;
            product.CategoryId = input.Category?.Id;
            product.UnitlineId = input.Unitline?.Id;

            await _productRepository.UpdateAsync(product);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            await _elasticSearchManager.AddOrUpdateIndexAsync<Product, int>(product);

            return MapToEntityDto(product);
        }

        protected override IQueryable<Product> CreateFilteredQuery(GetAllProductInput input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(input.Name) ||
                    x.Descr.Contains(input.Name) ||
                    x.Category.Name.Contains(input.Name) ||
                    x.Unitline.UnitType.Contains(input.Name))
                .Where(x => x.IsDeleted.Equals(input.IsDeleted));
        }

        public async Task<List<ProductFullOutPut>> GetList()
        {
            var products = await _productRepository.GetAllListAsync(x => x.IsDeleted.Equals(false));
            return ObjectMapper.Map<List<ProductFullOutPut>>(products);
        }
    }
}
