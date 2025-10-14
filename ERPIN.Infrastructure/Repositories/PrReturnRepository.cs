using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class PrReturnRepository : Repository<PrReturn>, IPrReturnRepository
{
    public PrReturnRepository(AppDbContext context) : base(context)
    {
    }

}
