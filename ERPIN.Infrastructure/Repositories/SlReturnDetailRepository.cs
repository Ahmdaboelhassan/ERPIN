using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public  class SlReturnDetailRepository : Repository<SlReturnDetail>, ISlReturnDetailRepository
{
    public SlReturnDetailRepository(AppDbContext context) : base(context)
    {
    }

}
