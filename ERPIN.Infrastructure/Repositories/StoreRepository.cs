using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class StoreRepository : Repository<Store>, IStoreRepository
{
    public StoreRepository(AppDbContext context) : base(context)
    {
    }
}
