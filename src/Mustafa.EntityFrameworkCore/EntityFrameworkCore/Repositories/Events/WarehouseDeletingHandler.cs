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
    public class WarehouseDeletingHandler : IEventHandler<EntityDeletingEventData<Warehouse>>, ITransientDependency
    {
        private readonly IStockMoveRepository _stockMoveRepository;

        public WarehouseDeletingHandler(IStockMoveRepository stockMoveRepository)
        {
            _stockMoveRepository = stockMoveRepository;
        }

        public void HandleEvent(EntityDeletingEventData<Warehouse> eventData)
        {
            var warehouse = eventData.Entity;

            foreach (var stockMove in warehouse.GetStockMove)
            {
                _stockMoveRepository.DeleteAsync(stockMove.Id);
            }
        }
    }
}
