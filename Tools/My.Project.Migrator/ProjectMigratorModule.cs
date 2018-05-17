using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using My.Project.EntityFramework;

namespace My.Project.Migrator
{
    [DependsOn(typeof(ProjectDataModule))]
    public class ProjectMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ProjectDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}