using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class PrReturnDetailRepository : Repository<PrReturnDetail>, IPrReturnDetailRepository
{
    public PrReturnDetailRepository(AppDbContext context) : base(context)
    {
    }

}
