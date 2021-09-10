using Membership.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class BlogController : Controller
    {
        //  private EsClient esClient;
        public BlogController()
        {
            //esClient = new EsClient();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new BlogViewModel();
            Filter(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BlogViewModel model)
        {
            Filter(model);
            return View(model);
        }

        private BlogViewModel Filter(BlogViewModel model)
        {
            var node = new Uri(ConfigurationManager.AppSettings["ElasticSearch"]);
            var _settings = new ConnectionSettings(node).DefaultIndex("article");
            var client = new ElasticClient(_settings);

            GetAverageRating();
            var searchResponse = client.Search<BlogModel>(s => s
                                       .From(0)
                                       .Size(10)
                                       .Query(q => q
                                              .Match(m => m
                                                    .Field(f => f.Title)
                                                    .Query(model.Title)
                                             )
                                       ));

            model.ListOfModel = searchResponse.Documents.ToList();
            return model;
        } 

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogModel model)
        {
            if (ModelState.IsValid)
            { 
                var node = new Uri(ConfigurationManager.AppSettings["ElasticSearch"]);
                var _settings = new ConnectionSettings(node).DefaultIndex("article");
                var client = new ElasticClient(_settings);

                var indexResponse = client.IndexDocument(model);
                return RedirectToAction("index");
                //var asyncIndexResponse = await esClient.client.IndexDocumentAsync(blog);
            }
            return View(model);
        }

        //demo of Aggregation
        public JsonResult GetAverageRating()
        {
            var node = new Uri(ConfigurationManager.AppSettings["ElasticSearch"]);
            var _settings = new ConnectionSettings(node).DefaultIndex("article");
            var client = new ElasticClient(_settings);

            var result = client.Search<BlogModel>(s => s
                                       .From(0)
                                       .Size(10)
                                       .Aggregations(a => a
                                                      .Stats("Rating", b => b
                                                      .Field(f => f.Rating)))
                                          );
            //var Statistics = new StatsModel
            //{
            var Statistics = result.Aggregations.Values;
            foreach(var data in Statistics)
            {
                //data.
                var datas = data.Meta;  
                //var model = new StatsModel
                //{
                //    Avg = data.Meta
                //};
            }
            //}
            return Json(Statistics, JsonRequestBehavior.AllowGet);
        }
    }
}