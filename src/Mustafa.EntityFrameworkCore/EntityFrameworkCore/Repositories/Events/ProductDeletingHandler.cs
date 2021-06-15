using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.EntityFrameworkCore.Repositories.Events
{
    public class ProductDeletingHandler : IEventHandler<EntityDeletingEventData<Product>>, ITransientDependency
    {
        private readonly IStockMoveRepository _stockMoveRepository;
        public ProductDeletingHandler(IStockMoveRepository stockMoveRepository)
        {
            _stockMoveRepository = stockMoveRepository;
        }

        public void HandleEvent(EntityDeletingEventData<Product> eventData)
        {
            var product = eventData.Entity;
            foreach(var stockMove in product.GetStockMoves)
            {
                _stockMoveRepository.DeleteAsync(stockMove.Id);
            }
        }
    }
}
