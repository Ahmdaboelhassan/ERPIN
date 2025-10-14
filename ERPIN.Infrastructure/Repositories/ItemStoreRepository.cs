using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
internal class ItemStoreRepository : Repository<ItemStore>, IItemStoreRepository
{
    public ItemStoreRepository(AppDbContext context) : base(context)
    {
    }
}
