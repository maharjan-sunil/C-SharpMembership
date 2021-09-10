using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Membership.Connection
{
    public class EsClient
    {
        private ConnectionSettings _settings;

        public ElasticClient client { get; set; }

        public EsClient()
        {
            var node = new Uri(ConfigurationManager.AppSettings["ElasticSearch"]);
            var _settings = new ConnectionSettings(node).DefaultIndex("article");
            var client = new ElasticClient(_settings);
        }
    }
}