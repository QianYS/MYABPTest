using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using Abp.Zero.EntityFramework;
using My.Project.Authorization.Roles;
using My.Project.Authorization.Users;
using My.Project.MultiTenancy;
using My.Project.UnitManagement.Companies;

namespace My.Project.EntityFramework
{
    public class ProjectDbContextAddOne : AbpDbContext
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Company> Company { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ProjectDbContextAddOne()
            : base("AddOne")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ProjectDbContext since ABP automatically handles it.
         */
        public ProjectDbContextAddOne(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ProjectDbContextAddOne(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public ProjectDbContextAddOne(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
