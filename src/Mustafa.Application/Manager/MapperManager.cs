using AutoMapper;
using Mustafa.Domain.Categories.Dtos;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Products.Dtos;
using Mustafa.Domain.StockMoves.Dtos;
using Mustafa.Domain.StockMoveTypes.Dto;
using Mustafa.Domain.Unitlines.Dto;
using Mustafa.Domain.Vendors.Dtos;
using Mustafa.Domain.Warehouses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Manager
{
    public class MapperManager
    {
        public static void DtosToDomain(IMapperConfigurationExpression cfg)
        {
            //Products
            cfg.CreateMap<Product, CreateProductInput>();
            cfg.CreateMap<Product, GetAllProductInput>();
            cfg.CreateMap<Product, DeleteProductInput>();
            cfg.CreateMap<Product, UpdateProductInput>();
            cfg.CreateMap<Product, ProductFullOutPut>();
            cfg.CreateMap<Product, ProductPartOutPut>();
            cfg.CreateMap<Product, GetAllProductInput>();

            // Categorys
            cfg.CreateMap<Category, CreateCategoryInput>();
            cfg.CreateMap<Category, GetCategoryInput>();
            cfg.CreateMap<Category, DeleteCategoryInput>();
            cfg.CreateMap<Category, UpdateCategoryInput>();
            cfg.CreateMap<Category, CategoryFullOutPut>();
            cfg.CreateMap<Category, CategoryPartOutPut>();
            cfg.CreateMap<Category, GetAllCategoryInput>();

            // StockMoves
            cfg.CreateMap<StockMove, CreateStockMoveInput>();
            cfg.CreateMap<StockMove, GetStockMoveInput>();
            cfg.CreateMap<StockMove, DeleteStockMoveInput>();
            cfg.CreateMap<StockMove, UpdateStockMoveInput>();
            cfg.CreateMap<StockMove, StockMoveFullOutPut>();
            cfg.CreateMap<StockMove, StockMovePartOutPut>();
            cfg.CreateMap<StockMove, GetAllStockMoveInput>();

            // StockMoveTypes
            cfg.CreateMap<StockMoveType, StockMoveTypeDto>();

            // Unitlines
            cfg.CreateMap<Unitline, UnitlineDto>();
            cfg.CreateMap<Unitline, CreateUnitlineInput>();
            cfg.CreateMap<Unitline, GetAllUnitlineInput>();
            cfg.CreateMap<Unitline, GetUnitlineInput>();
            cfg.CreateMap<Unitline, DeleteUnitlineInput>();
            cfg.CreateMap<Unitline, UnitlinePartOutPut>();
            cfg.CreateMap<Unitline, UpdateUnitlineInput>();

            // Vendors
            cfg.CreateMap<Vendor, VendorDto>();
            cfg.CreateMap<Vendor, CreateVendorInput>();
            cfg.CreateMap<Vendor, GetAllVendorInput>();
            cfg.CreateMap<Vendor, UpdateVendorInput>();
            cfg.CreateMap<Vendor, GetVendorInput>();
            cfg.CreateMap<Vendor, DeleteVendotInput>();

            // Warhouses
            cfg.CreateMap<Warehouse, WarehouseDto>();
            cfg.CreateMap<Warehouse, UpdateWarehouseInput>();
            cfg.CreateMap<Warehouse, GetAllWarehouseInput>();
            cfg.CreateMap<Warehouse, CreateWarehouseInput>();;
            cfg.CreateMap<Warehouse, GetWarehouseInput>();
            cfg.CreateMap<Warehouse, DeleteWarehouseInput>();
        }
    }
}
