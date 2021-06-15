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
    public class UnitlineDeletingHandler : IEventHandler<EntityDeletingEventData<Unitline>>, ITransientDependency
    {
        private readonly IProductRepository _productRepository;

        public UnitlineDeletingHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void HandleEvent(EntityDeletingEventData<Unitline> eventData)
        {
            var unitline = eventData.Entity;

            foreach (var product in unitline.GetProducts)
            {
                _productRepository.DeleteAsync(product.Id);
            }
        }
    }
}
