using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace My.Project.EntityFramework.Repositories
{
    public abstract class ProjectRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ProjectRepositoryBase(IDbContextProvider<ProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ProjectRepositoryBase<TEntity> : ProjectRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ProjectRepositoryBase(IDbContextProvider<ProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
