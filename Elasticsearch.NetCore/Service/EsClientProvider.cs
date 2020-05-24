using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elasticsearch.NetCore.Service
{
    public class EsClientProvider : IEsClientProvider
    {
        private readonly IConfiguration _configuration;
        private ElasticClient _client;
        public EsClientProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ElasticClient GetClient()
        {
            if (_client != null)
                return _client;

            InitClient();
            return _client;
        }

        private void InitClient()
        {
            var url = _configuration["elasticsearch:url"];
            var defaultIndex = _configuration["elasticsearch:index"];

            var node = new Uri(url);
            _client = new ElasticClient(new ConnectionSettings(node).DefaultIndex(defaultIndex));
        }


    }
}
