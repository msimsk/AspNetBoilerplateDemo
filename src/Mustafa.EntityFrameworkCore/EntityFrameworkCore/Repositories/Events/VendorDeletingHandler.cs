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
    public class VendorDeletingHandler : IEventHandler<EntityDeletingEventData<Vendor>>, ITransientDependency
    {
        private readonly IStockMoveRepository _stockMoveRepository;

        public VendorDeletingHandler(IStockMoveRepository stockMoveRepository)
        {
            _stockMoveRepository = stockMoveRepository;
        }

        public void HandleEvent(EntityDeletingEventData<Vendor> eventData)
        {
            var vendor = eventData.Entity;

            foreach (var stockMove in vendor.GetStockMove)
            {
                _stockMoveRepository.DeleteAsync(stockMove.Id);
            }
        }
    }
}
