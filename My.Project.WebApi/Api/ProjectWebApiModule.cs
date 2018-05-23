using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;

namespace My.Project.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ProjectApplicationModule))]
    public class ProjectWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ProjectApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));

            ConfigureSwaggerUi();
        }

        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "人事系统Api文档");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.UseFullTypeNameInSchemaIds();
                    //将注释的XML文档添加到SwaggerUI中
                    //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    //var commentsFileName = "bin/My.Project.Application.XML";
                    //var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    //c.IncludeXmlComments(commentsFile);
                })
                //.EnableSwaggerUi();
                .EnableSwaggerUi("apidoc/{*assetPath}", c =>
                {
                    c.InjectJavaScript(Assembly.GetAssembly(typeof(ProjectWebApiModule)), "My.Project.Api.Scripts.Swagger-Custom.js");
                });
        }
    }
}
