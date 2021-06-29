
using Abp.Domain.Entities.Auditing;

using System.Threading.Tasks;

namespace Mustafa.ElasticSearchs
{
    public interface IElasticSearchManager
    {
        public void CreateIndexAsync<T, TKey>(string indexName) where T : FullAuditedEntity<TKey>;
        public Task AddOrUpdateAsync<T, TKey>(string indexName, T model) where T : FullAuditedEntity<TKey>;
        public Task AddOrUpdateIndexAsync<T, TKey>(T model) where T : FullAuditedEntity<TKey>;
    }
}
