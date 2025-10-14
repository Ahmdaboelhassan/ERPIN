using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class SlReturnRepository : Repository<SlReturn>, ISlReturnRepository
{
    public SlReturnRepository(AppDbContext context) : base(context)
    {
    }

}
