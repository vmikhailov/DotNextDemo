using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;

namespace DotNextRZD.PublicApi.Swagger
{
    internal static class SwaggerInitialization
    {
        public static void RegisterSwagger(this HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "DotNextRZD.PublicAPI")
                    .Description("DotNextRZD Public API")
                    .TermsOfService("Terms and conditions")
                    .Contact(cc => cc
                        .Name("Vyacheslav Mikhaylov")
                        .Url("http://www.dotnextrzd.com")
                        .Email("vmikhaylov@dataart.com"))
                    .License(lc => lc
                        .Name("License")
                        .Url("http://tempuri.org/license"));
                c.IncludeXmlComments(GetXmlCommentFile());
                c.GroupActionsBy(GetControllerGroupingKey);
                c.OrderActionGroupsBy(new CustomActionNameComparer());
                c.CustomProvider(p => new CustomSwaggerProvider(config, p));
            })
                .EnableSwaggerUi(
                    c =>
                    {
                        c.InjectStylesheet(Assembly.GetExecutingAssembly(),
                            "DotNextRZD.PublicApi.Swagger.Styles.SwaggerCustom.css");
                    }
                );
        }

        private static string GetXmlCommentFile()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "bin\\";
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            return commentsFile;
        }

        private static string GetControllerGroupingKey(ApiDescription apiDesc)
        {
            var cd = apiDesc.ActionDescriptor.ControllerDescriptor;
            var descAttr = cd.ControllerType.GetCustomAttribute<SwaggerDescriptionAttribute>(false);
            var cname = descAttr == null || string.IsNullOrEmpty(descAttr.ControllerTag)
                ? cd.ControllerName
                : descAttr.ControllerTag;
            return cname;
        }

        internal class CustomActionNameComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return StringComparer.CurrentCultureIgnoreCase.Compare(x, y);
            }
        }
    }
}