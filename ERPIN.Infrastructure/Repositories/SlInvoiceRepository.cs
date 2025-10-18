using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class SlInvoiceRepository : Repository<SLInvoice>, ISlInvoiceRepository
{
    public SlInvoiceRepository(AppDbContext context) : base(context)
    {
    }

}
