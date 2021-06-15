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
    public class CategoryDeletingHandler : IEventHandler<EntityDeletingEventData<Category>>, ITransientDependency
    {
        private readonly IProductRepository _productRepository;

        public CategoryDeletingHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void HandleEvent(EntityDeletingEventData<Category> eventData)
        {
            var category = eventData.Entity;

            foreach (var product in category.GetProducts)
            {
                //product.CategoryId = 1;
                //_productRepository.Update(product);
                _productRepository.DeleteAsync(product.Id);
            }
        }
    }
}
