using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YF.SharedKernel.Common.Persistence;

namespace PriceScrapper.Infrastructure.Persistence;

public class EFRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class
{
    public EFRepository(DbContext dbContext) 
        : base(dbContext)
    {
    }
}
