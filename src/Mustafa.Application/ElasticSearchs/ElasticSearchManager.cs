using Abp;
using Abp.Domain.Entities.Auditing;
using Nest;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mustafa.ElasticSearchs
{
    public class ElasticSearchManager : IElasticSearchManager
    {
        public IElasticClient ElasticSearchClient { get; set; }
        private readonly IElasticSearchConfigration _elasticSearchConfigration;
        public ElasticSearchManager(IElasticSearchConfigration elasticSearchConfigration)
        {
            _elasticSearchConfigration = elasticSearchConfigration;
            ElasticSearchClient = GetClient();
        }
        private ElasticClient GetClient()
        {
            var str = _elasticSearchConfigration.ConnectionString;
            var strs = str.Split('|');
            var nodes = strs.Select(s => new Uri(s)).ToList();

            var connectionString = new ConnectionSettings(new Uri(str))
                .DisablePing()
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false);

            if (!string.IsNullOrEmpty(_elasticSearchConfigration.AuthUserName) && !string.IsNullOrEmpty(_elasticSearchConfigration.AuthPassWord))
                connectionString.BasicAuthentication(_elasticSearchConfigration.AuthUserName, _elasticSearchConfigration.AuthPassWord);

            return new ElasticClient(connectionString);
        }

        public void CreateIndexAsync<T, TKey>(string indexName) where T : FullAuditedEntity<TKey>
        {
            var a = ElasticSearchClient.Indices.Create(indexName, x => x
                    .Map<T>(y => y
                        .AutoMap()
                ));
        }

        public async Task AddOrUpdateAsync<T, TKey>(string indexName, T model) where T : FullAuditedEntity<TKey>
        {
            var exis = await ElasticSearchClient.BulkAsync(x => x
                .Index(indexName)
                .IndexMany(new T[] { model }));
        }

        public async Task AddOrUpdateIndexAsync<T, TKey>(T model) where T : FullAuditedEntity<TKey>
        {
            var appName = Assembly.GetExecutingAssembly().GetName().Name.ToLower().Split('.').First();
            var indexName = appName + "-" + typeof(T).Name.ToLower();

            if (!ElasticSearchClient.Indices.Exists(indexName).Exists)
                CreateIndexAsync<T, TKey>(indexName);
            await AddOrUpdateAsync<T, TKey>(indexName, model);
        }
    }

}
