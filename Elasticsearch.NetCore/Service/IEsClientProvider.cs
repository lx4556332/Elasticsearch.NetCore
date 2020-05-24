using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elasticsearch.NetCore.Service
{
    public interface IEsClientProvider
    {
        ElasticClient GetClient();
    }
}
