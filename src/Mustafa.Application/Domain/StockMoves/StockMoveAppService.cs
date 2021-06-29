using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using Mustafa;
using Mustafa.Authorization;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Products.Dtos;
using Mustafa.Domain.StockMoves;
using Mustafa.Domain.StockMoves.Dtos;
using Mustafa.ElasticSearchs;
using Mustafa.EntityFrameworkCore.Repositories;
using Mustafa.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MustafaDenemeCore.Domain.StockMoves
{
    [AbpAuthorize(PermissionNames.StockMove)]
    public class StockMoveAppService : AsyncCrudAppService<StockMove, StockMoveFullOutPut, Int64, GetAllStockMoveInput, CreateStockMoveInput, UpdateStockMoveInput, GetStockMoveInput, DeleteStockMoveInput>, IStockMoveAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IStockMoveRepository _stockMoveRepository;
        private readonly IProductRepository _productRepository;
        private readonly IElasticSearchManager _elasticSearchManager;
        public StockMoveAppService(
            IUnitOfWorkManager unitOfWorkManager,
            IStockMoveRepository stockMoveRepository,
            IProductRepository productRepository,
            IElasticSearchManager elasticSearchManager,
            IRepository<StockMove, Int64> repository) : base(repository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _stockMoveRepository = stockMoveRepository;
            _productRepository = productRepository;
            _elasticSearchManager = elasticSearchManager;
        }

        [AbpAuthorize(PermissionNames.StockMove_Create)]
        public override async Task<StockMoveFullOutPut> CreateAsync(CreateStockMoveInput input)
        {
            var stockMove = new StockMove()
            {
               
                Descr = input.Descr,
                UnitPrice = input.UnitPrice,
                Quantity = input.Quantity,
                ProductId = input.Product.Id,
                VendorId = input.Vendor.Id,
                WarehouseId = input.Warehouse.Id,
                StockMoveTypeId = input.StockMoveType.Id
            };

            stockMove.Id = await _stockMoveRepository.InsertAndGetIdAsync(stockMove);
            //*** update last price
            if (input.StockMoveType.Id == StockMoveType.Giris) 
            { 
                var product = await _productRepository.GetAsync(input.Product.Id);
                product.LastPrice = input.UnitPrice <= 0 ? product.LastPrice : input.UnitPrice;
                await _productRepository.UpdateAsync(product);
            }
            //await _unitOfWorkManager.Current.SaveChangesAsync();
            await _elasticSearchManager.AddOrUpdateIndexAsync<StockMove, Int64>(stockMove);

            return MapToEntityDto(stockMove);
            //return await base.CreateAsync(input);
        }
        
        [AbpAuthorize(PermissionNames.StockMove_Delete)]
        public override async Task DeleteAsync(DeleteStockMoveInput input)
        {
            var stockMove = await _stockMoveRepository.GetAsync(input.Id);

            if (stockMove == null) throw new EntityNotFoundException(typeof(StockMove), input);

            stockMove.IsDeleted = true;

            //*** last price update
            var lastStockMove = _stockMoveRepository.GetAll()
                .Where(x => x.IsDeleted.Equals(false) && x.ProductId.Equals(stockMove.ProductId) && x.StockMoveTypeId == StockMoveType.Giris)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();
            var product = await _productRepository.GetAsync(stockMove.ProductId);
            product.LastPrice = lastStockMove != null ? lastStockMove.UnitPrice : 0;

            await _productRepository.UpdateAsync(product);
            await _stockMoveRepository.DeleteAsync(stockMove);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            await _elasticSearchManager.AddOrUpdateIndexAsync<StockMove, Int64>(stockMove);
        }

        [AbpAuthorize(PermissionNames.StockMove_Get)]
        public override async Task<StockMoveFullOutPut> GetAsync(GetStockMoveInput input)
        {
            //var stockMove = _stockMoveRepository
            //    .GetAllIncluding(x => x.Product, x => x.Vendor, x => x.Warehouse, x => x.StockMoveType)
            //    .Where(x => x.Id.Equals(input.Id))
            //    .First();
            //if (stockMove == null) throw new EntityNotFoundException(typeof(StockMove), input);
            //return MapToEntityDto(stockMove);
            return await base.GetAsync(input);
        }

        [AbpAuthorize(PermissionNames.StockMove_GetList)]
        public override async Task<PagedResultDto<StockMoveFullOutPut>> GetAllAsync(GetAllStockMoveInput input)
        { 
            return await base.GetAllAsync(input);
        }
        
        [AbpAuthorize(PermissionNames.StockMove_Update)]
        public override async Task<StockMoveFullOutPut> UpdateAsync(UpdateStockMoveInput input)
        {
            var isChangePrice = false;
            var stockMove = await _stockMoveRepository.GetAsync(input.Id);

            if (stockMove == null) throw new EntityNotFoundException(typeof(StockMove), input);

            if (stockMove.UnitPrice != input.UnitPrice && input.StockMoveType.Id == StockMoveType.Giris) isChangePrice = true;

            stockMove.Descr = input.Descr.IsNullOrEmpty() ? stockMove.Descr : input.Descr;
            stockMove.UnitPrice = input.UnitPrice;
            stockMove.Quantity = input.Quantity;
            stockMove.ProductId = input.Product.Id;
            stockMove.VendorId = input.Vendor.Id;
            stockMove.WarehouseId = input.Warehouse.Id;
            stockMove.StockMoveTypeId = input.StockMoveType.Id;

            if (isChangePrice && stockMove.UnitPrice > 0)
            {
                var product = await _productRepository.GetAsync(stockMove.ProductId);
                product.LastPrice = stockMove.UnitPrice;
                await _productRepository.UpdateAsync(product);
            }

            await _stockMoveRepository.UpdateAsync(stockMove);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            await _elasticSearchManager.AddOrUpdateIndexAsync<StockMove, Int64>(stockMove);

            return MapToEntityDto(stockMove);
        }

        protected override IQueryable<StockMove> CreateFilteredQuery(GetAllStockMoveInput input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(),
                    x => x.Descr.Contains(input.Name) ||
                    x.Product.Name.Contains(input.Name) ||
                    x.Warehouse.Name.Contains(input.Name) ||
                    x.StockMoveType.TYPE.Contains(input.Name) ||
                    x.Vendor.Name.Contains(input.Name))
                .Where(x => x.IsDeleted.Equals(input.IsDeleted));
        }

        public Task<List<StockMoveFullOutPut>> GetList()
        {
            throw new NotImplementedException();
        }
        public static class StockMoveType 
        {
            public const bool Giris = true;
            public const bool Cikis = false;
        }
    }
}
