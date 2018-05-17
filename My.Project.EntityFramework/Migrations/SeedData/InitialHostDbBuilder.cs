using My.Project.EntityFramework;
using EntityFramework.DynamicFilters;

namespace My.Project.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ProjectDbContext _context;

        public InitialHostDbBuilder(ProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
