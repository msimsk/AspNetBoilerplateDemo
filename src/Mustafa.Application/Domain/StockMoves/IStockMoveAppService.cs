using Abp.Application.Services;
using Mustafa.Domain.StockMoves.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mustafa.Domain.StockMoves
{
    public interface IStockMoveAppService : IAsyncCrudAppService<StockMoveFullOutPut, Int64, GetAllStockMoveInput, CreateStockMoveInput, UpdateStockMoveInput, GetStockMoveInput, DeleteStockMoveInput>
    {
        Task<List<StockMoveFullOutPut>> GetList();
    }
}
