using System.Web.Http;
using WebActivatorEx;
using GadgetOnline;
using Swashbuckle.Application;
using System.Configuration;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GadgetOnline
{
   

    public class SwaggerConfig
    {
          public static void Register(HttpConfiguration config)
            {
                //    var thisAssembly = typeof(SwaggerConfig).Assembly;
                //  GlobalConfiguration.Configuration
                config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", ConfigurationManager.AppSettings["ApplicationName"]);
                })
                .EnableSwaggerUi();
            }
        
    }
}
