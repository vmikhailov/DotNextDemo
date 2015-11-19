using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace DotNextRZD.PublicApi.Swagger
{
    internal class CustomSwaggerProvider : ISwaggerProvider
    {
        private static readonly Dictionary<string, SwaggerDocument> docs = new Dictionary<string, SwaggerDocument>();
        private readonly IApiExplorer apiExplorer;
        private readonly ISwaggerProvider provider;

        public CustomSwaggerProvider(HttpConfiguration config, ISwaggerProvider source)
        {
            provider = source;
            apiExplorer = config.Services.GetApiExplorer();
        }

        public SwaggerDocument GetSwagger(string rootUrl, string apiVersion)
        {
            SwaggerDocument doc;
            var key = rootUrl + apiVersion;
            if (!docs.TryGetValue(key, out doc))
            {
                doc = provider.GetSwagger(rootUrl, apiVersion);
                AddControllerTags(doc);
                SortPaths(doc);
                docs.Add(key, doc);
            }
            return doc;
        }

        private void SortPaths(SwaggerDocument doc)
        {
            doc.paths = new SortedDictionary<string, PathItem>(doc.paths, new CustomPathItemComparer());
        }

        private void AddControllerTags(SwaggerDocument doc)
        {
            doc.tags = new List<Tag>();
            var controllers =
                apiExplorer.ApiDescriptions.Select(c => c.ActionDescriptor.ControllerDescriptor)
                    .Distinct()
                    .ToList();
            foreach (var c in controllers)
            {
                var descAttr = c.ControllerType.GetCustomAttribute<SwaggerDescriptionAttribute>(false);
                if (descAttr == null) continue;
                var cname = descAttr.ControllerTag ?? c.ControllerName;
                var tag = doc.tags.FirstOrDefault(x => x.name == cname);
                if (tag == null)
                {
                    tag = new Tag {name = cname};
                    doc.tags.Add(tag);
                }
                tag.description = tag.description ?? descAttr.ControllerDescription;
            }
        }

        private class CustomPathItemComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                var len = x.Length.CompareTo(y.Length);
                return len != 0 ? len : x.CompareTo(y);
            }
        }
    }
}