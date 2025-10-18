using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class VendorRepository : Repository<Vendor>, IVendorRepository
{
    public VendorRepository(AppDbContext context) : base(context)
    {
    }
}
