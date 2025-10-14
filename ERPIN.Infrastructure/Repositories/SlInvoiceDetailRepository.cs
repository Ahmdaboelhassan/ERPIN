using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class SlInvoiceDetailRepository : Repository<SlInvoiceDetail>, ISlInvoiceDetailRepository
{
    public SlInvoiceDetailRepository(AppDbContext context) : base(context)
    {
    }
}
