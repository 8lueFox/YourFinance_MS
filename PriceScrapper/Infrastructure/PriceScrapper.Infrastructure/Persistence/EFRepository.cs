using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Mapster;
using Microsoft.EntityFrameworkCore;
using YF.SharedKernel.Common.Persistence;

namespace PriceScrapper.Infrastructure.Persistence;

public class EFRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class
{
    public EFRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
    }

    protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();
}
